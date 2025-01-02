using FluentValidation;
using MediatR;

namespace Reservations.Application.User.AuthUser;

public class AuthUserCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class AuthUserCommandValidator : AbstractValidator<AuthUserCommand>
{
    public AuthUserCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress()
            .WithMessage("El email no es válido");
        RuleFor(x => x.Password).NotEmpty()
            .WithMessage("La contraseña no puede estar vacía");
    }
}