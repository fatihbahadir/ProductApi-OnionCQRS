using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ProductApi.Application.Bases;
using ProductApi.Application.Features.Auth.Rules;
using ProductApi.Application.Interfaces.AutoMapper;
using ProductApi.Application.Interfaces.Tokens;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Features.Auth.Command.Login;

public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly UserManager<User> userManager;
    private readonly ITokenService tokenService;
    private readonly IConfiguration configuration;
    private readonly AuthRules authRules;

    public LoginCommandHandler(UserManager<User> userManager,ITokenService tokenService, IConfiguration configuration, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.tokenService = tokenService;
        this.configuration = configuration;
        this.authRules = authRules;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByEmailAsync(request.Email);
        bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

        await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

        IList<string> roles = await userManager.GetRolesAsync(user);

        JwtSecurityToken token = await tokenService.CreateToken(user, roles);
        string refreshToken = tokenService.GenerateRefreshToken();

        _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDays);

        await userManager.UpdateAsync(user);
        await userManager.UpdateSecurityStampAsync(user);

        string _token = new JwtSecurityTokenHandler().WriteToken(token);

        await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

        return new()
        {
            Token = _token,
            RefreshToken = refreshToken,
            Expiration = token.ValidTo
        };
    }
}