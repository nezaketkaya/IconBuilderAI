using IconBuilderAI.Application.Features.Orders.Commands.Delete;
using IconBuilderAI.Application.Features.Orders.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IconBuilderAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly ISender _mediatr;

        public OrdersController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{id:guid")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new OrderGetByIdQuery(id), cancellationToken));
        }


        [HttpDelete("{id:guid")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new OrderDeleteCommand(id), cancellationToken));
        }
    }
}
