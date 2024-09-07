using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models.OpenAI;

namespace IconBuilderAI.Infrastructure.Services
{
    public class OpenAIManager : IOpenAIService
    {
        // Betalgo.OpenAI NuGet package
        public Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
