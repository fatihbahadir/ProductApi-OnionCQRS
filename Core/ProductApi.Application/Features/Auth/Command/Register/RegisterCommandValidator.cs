using FluentValidation;

namespace ProductApi.Application.Features.Auth.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{

    public RegisterCommandValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(50).MinimumLength(2).WithName("Name Surname");
        RuleFor(x => x.Email).NotEmpty().MaximumLength(60).EmailAddress().MinimumLength(8).WithName("Email address");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(6).Equal(x => x.Password);
    }
}