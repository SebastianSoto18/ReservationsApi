using MediatR;
using Reservations.Application.Services;
using Reservations.Domain;

namespace Reservations.Application.User.AuthUser;

public class AuthUserHandler(IUserRepository userRepository, IEncryptService encryptService, ITokenService tokenService, IExceptionService exceptionService) : IRequestHandler<AuthUserCommand, string>
{
    public async Task<string> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email);
        
        if (user == null)
        {
            exceptionService.ThrowExc("Usuario no existe", 404);
        }
        
        if(encryptService.VerifyPassword(request.Password, user.Password))
        {
            return tokenService.GenerateTokenAsync(user);
        }

        exceptionService.ThrowExc("Contraseña incorrecta", 404);
        return String.Empty;
    }
}