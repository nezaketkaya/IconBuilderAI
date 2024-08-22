using IconBuilderAI.Application.Common.Models;
using IconBuilderAI.Domain.Identity;

namespace IconBuilderAI.Application.Common.Interfaces
{
    public interface IJwtService 
    {
        JwtDto GenerateToken(User user, List<string> roles);
        Task<JwtDto> GenerateTokenAsync(Guid userId, string email, CancellationToken cancellationToken);
    }
}
