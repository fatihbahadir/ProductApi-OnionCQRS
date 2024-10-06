using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProductApi.Application.Bases;
using ProductApi.Application.Features.Auth.Rules;
using ProductApi.Application.Interfaces.AutoMapper;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Features.Auth.Command.Revoke;

public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<User> userManager;
    private readonly AuthRules authRules;

    public RevokeCommandHandler(UserManager<User> userManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.authRules = authRules;
    }

    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByEmailAsync(request.Email);
        await authRules.EmailAdressShouldBeValid(user);

        user.RefreshToken = null;
        await userManager.UpdateAsync(user);

        return Unit.Value;
    }
}