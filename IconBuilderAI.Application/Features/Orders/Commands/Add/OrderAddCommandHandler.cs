using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models;
using IconBuilderAI.Application.Common.Models.OpenAI;
using MediatR;

namespace IconBuilderAI.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IOpenAIService _openAiService;

        public OrderAddCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService, IOpenAIService openAiService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _openAiService = openAiService;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var order = OrderAddCommand.MapToOrder(request);

            order.UserId = _currentUserService.UserId;
            order.CreatedByUserId = _currentUserService.UserId.ToString();
            order.Urls =
              await _openAiService.DallECreateIconAsync(DallECreateIconRequestDto.MapFromOrderAddCommand(request),
                  cancellationToken);

            _dbContext.Orders.Add(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(order.Id, "Your order complated successfully.");
        }
    }
}
