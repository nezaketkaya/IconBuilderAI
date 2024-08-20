using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Domain.Settings;
using Microsoft.Extensions.Options;

namespace IconBuilderAI.Infrastructure.Services
{
    public class JwtManager : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtManager(IOptions<JwtSettings> jwtSettingsOptions)
        {
            _jwtSettings = jwtSettingsOptions.Value;
        }
    }
}
