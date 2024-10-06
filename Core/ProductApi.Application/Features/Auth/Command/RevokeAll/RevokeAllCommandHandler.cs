using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductApi.Application.Bases;
using ProductApi.Application.Features.Auth.Command.Revoke;
using ProductApi.Application.Interfaces.AutoMapper;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Features.Auth.Command.RevokeAll;

public class RevokeAllCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<User> userManager;
    
    public RevokeAllCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
    }

    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        List<User> users = await userManager.Users.ToListAsync(cancellationToken);

        foreach (User user in users)
        {
            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
        }

        return Unit.Value;
    }
}