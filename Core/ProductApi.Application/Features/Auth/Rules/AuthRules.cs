using ProductApi.Application.Bases;
using ProductApi.Application.Features.Auth.Exceptions;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Features.Auth.Rules;

public class AuthRules : BaseRules
{
    public Task UserShouldNotBeExist(User? user)
    {
        if (user is not null) throw new UserAlreadyExistException();
        return Task.CompletedTask;
    }

    public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
    {
        if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldNotBeExpired(DateTime? expiryDate)
    {
        if (expiryDate <= DateTime.UtcNow) throw new RefreshTokenShouldNotBeExpiredException();
        return Task.CompletedTask;
    }

    public Task EmailAdressShouldBeValid(User? user)
    {
        if (user is null) throw new EmailAdressShouldBeValidException();
        return Task.CompletedTask;
    }
}