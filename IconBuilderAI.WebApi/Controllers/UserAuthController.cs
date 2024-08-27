using IconBuilderAI.Application.Features.UserAuth.Commands.Login;
using IconBuilderAI.Application.Features.UserAuth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IconBuilderAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly ISender _mediatr;

        public UserAuthController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }
    }
}
