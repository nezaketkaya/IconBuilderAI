using IconBuilderAI.Application.Common.Models;
using IconBuilderAI.Application.Common.Models.Auth;
using IconBuilderAI.Application.Features.UserAuth.Commands.Login;
using IconBuilderAI.Application.Features.UserAuth.Commands.Register;

namespace IconBuilderAI.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken);
        Task<JwtDto> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken);
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
        Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken);
    }
}
