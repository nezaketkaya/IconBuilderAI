using IconBuilderAI.Application.Common.Models;
using MediatR;

namespace IconBuilderAI.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommand : IRequest<ResponseDto<Guid>>
    {
        public Guid Id { get; set; }

        public OrderDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
