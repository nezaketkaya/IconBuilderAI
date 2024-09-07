using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models.OpenAI;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using IconBuilderAI.Domain.Enums;

namespace IconBuilderAI.Infrastructure.Services
{
    public class OpenAIManager : IOpenAIService
    {
        //Nuget paketindeki servisle karışmaması için
        private readonly OpenAI.Interfaces.IOpenAIService _openAIService;

        public OpenAIManager(OpenAI.Interfaces.IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        // Betalgo.OpenAI NuGet package
        public async Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken)
        {
            var imageResult = await _openAIService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = requestDto.Description,
                N = requestDto.Quantity,
                Size = GetSize(requestDto.Size),
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "TestUser"
            }, cancellationToken);

            return imageResult.Results.Select(x => x.Url).ToList();
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
    }
}
