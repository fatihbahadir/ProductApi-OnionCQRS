using System.ComponentModel;
using MediatR;

namespace ProductApi.Application.Features.Auth.Command.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    [DefaultValue("hunkarhyme@gmail.com")]
    public string Email { get; set; }

    [DefaultValue("123456")]
    public string Password { get; set; }
}