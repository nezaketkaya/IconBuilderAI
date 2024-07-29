using IconBuilderAI.Application.Features.Orders.Commands.Delete;
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


        [HttpDelete("{id:guid")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(new OrderDeleteCommand(id), cancellationToken));
        }
    }
}
