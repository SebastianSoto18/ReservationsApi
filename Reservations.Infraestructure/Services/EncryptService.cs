using DevOne.Security.Cryptography.BCrypt;
using Reservations.Application.Services;

namespace Reservations.Infraestructure.Services;

public class EncryptService : IEncryptService
{
    public bool VerifyPassword(string password, string passwordHash)
    {
        return  BCryptHelper.CheckPassword(password, passwordHash);
    }
}