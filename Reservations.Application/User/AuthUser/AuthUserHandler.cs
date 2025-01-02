using MediatR;
using Reservations.Application.Services;
using Reservations.Domain;

namespace Reservations.Application.User.AuthUser;

public class AuthUserHandler(IUserRepository userRepository, IEncryptService encryptService, ITokenService tokenService) : IRequestHandler<AuthUserCommand, string>
{
    public async Task<string> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync("123123");
        
        if (user == null)
        {
            throw new Exception("Invalid email or password");
        }
        
        if(encryptService.VerifyPassword("12312312", user.Password))
        {
            return tokenService.GenerateTokenAsync(user);
        }

        throw new Exception("Invalid email or password");
    }
}