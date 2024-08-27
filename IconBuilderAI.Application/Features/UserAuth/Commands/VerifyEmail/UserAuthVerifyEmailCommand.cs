using IconBuilderAI.Application.Common.Models;
using MediatR;

namespace IconBuilderAI.Application.Features.UserAuth.Commands.VerifyEmail
{
    public class UserAuthVerifyEmailCommand : IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public UserAuthVerifyEmailCommand(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}
