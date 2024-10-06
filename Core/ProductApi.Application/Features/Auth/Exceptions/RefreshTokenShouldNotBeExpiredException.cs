using ProductApi.Application.Bases;

namespace ProductApi.Application.Features.Auth.Exceptions;

public class RefreshTokenShouldNotBeExpiredException : BaseException
{
    public RefreshTokenShouldNotBeExpiredException() : base("Your session end. Please login again")
    {
        
    }
}