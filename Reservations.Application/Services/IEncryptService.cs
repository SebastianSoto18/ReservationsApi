namespace Reservations.Application.Services;

public interface IEncryptService
{
    bool VerifyPassword(string password, string passwordHash);
}