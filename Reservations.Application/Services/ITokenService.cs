namespace Reservations.Application.Services;

public interface ITokenService
{
    string GenerateTokenAsync(Domain.Models.User user);
}