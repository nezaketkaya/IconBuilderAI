using IconBuilderAI.Domain.Common;
using MediatR;

namespace IconBuilderAI.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, Response<Guid>>
    {
        public async Task<Response<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
