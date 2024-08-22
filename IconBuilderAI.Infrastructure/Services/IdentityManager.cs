using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models;
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

        public async Task<JwtDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var user = new User()
            {
                Id = id,
                Email = command.Email,
                UserName = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = id.ToString(),
                EmailConfirmed = true,
                Balance = new UserBalance()
                {
                    Id = Guid.NewGuid(),
                    Credits = 10,
                    UserId = id,
                    CreatedOn = DateTimeOffset.UtcNow,
                    CreatedByUserId = id.ToString(),
                }
            };
            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User registration failed.");
            }

            return await _jwtService.GenerateTokenAsync(user.Id, user.Email, cancellationToken);
        }

        public Task<JwtDto> SignInAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
