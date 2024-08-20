using MediatR;

namespace IconBuilderAI.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQuery : IRequest<List<OrderGetAllDto>>
    {
    }
}
