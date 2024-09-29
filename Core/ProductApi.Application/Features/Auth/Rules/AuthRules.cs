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
}