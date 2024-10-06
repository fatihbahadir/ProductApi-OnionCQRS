using ProductApi.Application.Bases;

namespace ProductApi.Application.Features.Auth.Exceptions;

public class EmailAdressShouldBeValidException : BaseException
{
    public EmailAdressShouldBeValidException() : base("This email address does not exists!")
    {
        
    }
}