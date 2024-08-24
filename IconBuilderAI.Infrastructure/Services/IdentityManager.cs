using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models;
using IconBuilderAI.Application.Common.Models.Auth;
using IconBuilderAI.Application.Features.UserAuth.Commands.Register;
using IconBuilderAI.Domain.Entities;
using IconBuilderAI.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace IconBuilderAI.Infrastructure.Services
{
    public class IdentityManager : IIdentityService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;

        public IdentityManager(IJwtService jwtService, UserManager<User> userManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }

        public async Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserAuthRegisterCommand.ToUser(command);

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User registration failed.");
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
             
            return new UserAuthRegisterResponseDto(user.Id, user.Email, user.FirstName, token);
        }

        public Task<JwtDto> SignInAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is not null)
                return true;

            return false;
        }
    }
}
