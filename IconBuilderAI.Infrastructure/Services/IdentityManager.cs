﻿using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models;
using IconBuilderAI.Application.Common.Models.Auth;
using IconBuilderAI.Application.Features.UserAuth.Commands.Login;
using IconBuilderAI.Application.Features.UserAuth.Commands.Register;
using IconBuilderAI.Application.Features.UserAuth.Commands.VerifyEmail;
using IconBuilderAI.Domain.Entities;
using IconBuilderAI.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is not null)
                return true;

            return false;
        }

        public async Task<JwtDto> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            var jwtDto = await _jwtService.GenerateTokenAsync(user.Id, user.Email, cancellationToken);

            return jwtDto;
        }

        public async Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) return false;

            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> VerifyEmailAsync(UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            var result = await _userManager.ConfirmEmailAsync(user, command.Token);

            if (!result.Succeeded)
            {
                throw new Exception("User's email verification failed.");
            }
            return true;
        }

        public Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken)
        {
            return _userManager.Users.AnyAsync(x => x.Email == email && x.EmailConfirmed, cancellationToken);
        }
    }
}
