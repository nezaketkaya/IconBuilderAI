using IconBuilderAI.Application.Common.Models.OpenAI;

namespace IconBuilderAI.Application.Common.Interfaces
{
    public interface IOpenAIService
    {
        Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken);
    }
}
