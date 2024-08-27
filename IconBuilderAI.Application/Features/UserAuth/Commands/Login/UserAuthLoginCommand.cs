using IconBuilderAI.Application.Common.Models;
using MediatR;

namespace IconBuilderAI.Application.Features.UserAuth.Commands.Login
{
    public class UserAuthLoginCommand : IRequest<ResponseDto<JwtDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
