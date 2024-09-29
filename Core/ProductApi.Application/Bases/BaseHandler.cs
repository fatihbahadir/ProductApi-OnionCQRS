using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ProductApi.Application.Interfaces.AutoMapper;
using ProductApi.Application.Interfaces.UnitOfWorks;

namespace ProductApi.Application.Bases;

public class BaseHandler
{
    public readonly IMapper mapper;
    public readonly IUnitOfWork unitOfWork;
    public readonly IHttpContextAccessor httpContextAccessor;
    public readonly string userId;

    public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.httpContextAccessor = httpContextAccessor;
        userId = httpContextAccessor.HttpContext.User.FindFirstValue((ClaimTypes.NameIdentifier));
    }
}