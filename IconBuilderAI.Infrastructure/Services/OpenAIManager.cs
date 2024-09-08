using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models.OpenAI;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using IconBuilderAI.Domain.Enums;
using MediatR;
using System.Text;

namespace IconBuilderAI.Infrastructure.Services
{
    public class OpenAIManager : IOpenAIService
    {
        private readonly ICurrentUserService _currentUserService;

        //Nuget paketindeki servisle karışmaması için
        private readonly OpenAI.Interfaces.IOpenAIService _openAiService;

        public OpenAIManager(OpenAI.Interfaces.IOpenAIService openAiService, ICurrentUserService currentUserService)
        {
            _openAiService = openAiService;
            _currentUserService = currentUserService;
        }

        // Betalgo.OpenAI NuGet package
        public async Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken)
        {
            var imageResult = await _openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = CreateIconPrompt(requestDto),
                N = requestDto.Model == AIModelType.DallE3 ? 1 : requestDto.Quantity,
                Size = GetSize(requestDto.Size),
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = _currentUserService.UserId.ToString(),
                Model = Models.Dall_e_3
            }, cancellationToken);
            // TODO: Add error handling / If the model is Dall-e-3, Image size must be at least 1024x1024
            if (!imageResult.Successful)
            {
                // Log the error or throw an exception
                throw new ApplicationException($"Failed to create image: {imageResult.Error?.Message}");
            }

            if (imageResult.Results == null || !imageResult.Results.Any())
            {
                // Log the error or throw an exception
                throw new ApplicationException("No image results were returned.");
            }

            return imageResult.Results
                              .Select(x => x.Url)
                              .Where(url => !string.IsNullOrEmpty(url))
                              .ToList();
        }

        private string GetSize(IconSize size)
        {
            return size switch
            {
                IconSize.Small => StaticValues.ImageStatics.Size.Size256,
                IconSize.Medium => StaticValues.ImageStatics.Size.Size512,
                IconSize.Large => StaticValues.ImageStatics.Size.Size1024,
                _ => StaticValues.ImageStatics.Size.Size256 //default
            };
        }

        private string CreateIconPrompt(DallECreateIconRequestDto request)
        {
            var promptBuilder = new StringBuilder();

            promptBuilder.Append(
                $"You're a World-class Icon Designer AI who is working on Mobile Application Icons. Generate icon with the following specifications: ");

            promptBuilder.Append(
                $"Design Type: {request.DesignType}, Colour Code (Hex Code): {request.ColourCode}, Shape: {request.Shape}, Description:{request.Description} ");

            promptBuilder.Append(
                $"I'll tip you 1000$ for your work, if I like it.");

            return promptBuilder.ToString();
        }
    }
}
