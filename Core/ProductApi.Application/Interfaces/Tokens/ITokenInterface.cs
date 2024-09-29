using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Interfaces.Tokens;

public interface ITokenService
{
    Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
    
    string GenerateRefreshToken();

    ClaimsPrincipal GetPrincipalFromExpiredToken(string? token);

}