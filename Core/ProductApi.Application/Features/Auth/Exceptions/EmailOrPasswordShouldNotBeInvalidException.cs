using ProductApi.Application.Bases;

namespace ProductApi.Application.Features.Auth.Exceptions;

public class EmailOrPasswordShouldNotBeInvalidException : BaseException
{
    public EmailOrPasswordShouldNotBeInvalidException() : base("Username or password is wrong") {}
}