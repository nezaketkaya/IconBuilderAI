using IconBuilderAI.Application.Common.Models;
using IconBuilderAI.Application.Features.UserAuth.Commands.Register;

namespace IconBuilderAI.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<JwtDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken);
        Task<JwtDto> SignInAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken);
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
    }
}
