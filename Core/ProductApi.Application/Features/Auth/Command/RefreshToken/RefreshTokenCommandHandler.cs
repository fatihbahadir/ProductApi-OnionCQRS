using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProductApi.Application.Bases;
using ProductApi.Application.Features.Auth.Rules;
using ProductApi.Application.Interfaces.AutoMapper;
using ProductApi.Application.Interfaces.Tokens;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Features.Auth.Command.RefreshToken;

public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
    private readonly UserManager<User> userManager;
    private readonly ITokenService tokenService;
    private readonly AuthRules authRules;

    public RefreshTokenCommandHandler(UserManager<User> userManager, ITokenService tokenService, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.tokenService = tokenService;
        this.authRules = authRules;
    }
    
    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        string email = principal.FindFirstValue(ClaimTypes.Email);

        User? user = await userManager.FindByEmailAsync(email);
        IList<string> roles = await userManager.GetRolesAsync(user);

        await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

        JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
        string newRefreshToken = tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await userManager.UpdateAsync(user);

        return new()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken
        };
    }
    
}