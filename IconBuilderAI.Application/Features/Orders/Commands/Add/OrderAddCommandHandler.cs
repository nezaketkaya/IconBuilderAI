using IconBuilderAI.Domain.Common;
using MediatR;
using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models;

namespace IconBuilderAI.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderAddCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseDto<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var order = OrderAddCommand.MapToOrder(request);

            order.CreatedByUserId = _currentUserService.UserId.ToString();

            _dbContext.Orders.Add(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(order.Id, "Your order complated successfully.");
        }
    }
}
