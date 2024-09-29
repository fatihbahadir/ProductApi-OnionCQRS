using ProductApi.Application.Bases;

namespace ProductApi.Application.Features.Auth.Exceptions;

public class UserAlreadyExistException : BaseException
{
    public UserAlreadyExistException() : base("This user already exists.")
    {
        
    }
}