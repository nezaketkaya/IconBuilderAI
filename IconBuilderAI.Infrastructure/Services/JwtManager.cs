﻿using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models;
using IconBuilderAI.Domain.Identity;
using IconBuilderAI.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IconBuilderAI.Infrastructure.Services
{
    public class JwtManager : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;

        public JwtManager(IOptions<JwtSettings> jwtSettingsOptions, UserManager<User> userManager)
        {
            _jwtSettings = jwtSettingsOptions.Value;
            _userManager = userManager;
        }

        public JwtDto GenerateToken(User user, List<string> roles)
        {
            throw new NotImplementedException();
        }

        public Task<JwtDto> GenerateTokenAsync(Guid userId, string email, CancellationToken cancellationToken)
        {
            var expirationTime = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpirationInMinutes);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("uid",userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss,_jwtSettings.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud,_jwtSettings.Audience),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToFileTimeUtc().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,expirationTime.ToFileTimeUtc().ToString()),
                new Claim("roles","CTO")
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            // We've created the signing credentials using the security key
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
               _jwtSettings.Issuer,
               _jwtSettings.Audience,
               claims,
               expires: expirationTime,
               signingCredentials: credentials
           );

            // We've written the JWT token to a string
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return Task.FromResult(new JwtDto(token, expirationTime));
        }
    }
}
