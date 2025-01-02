namespace Reservations.Application.Services;

public interface IExceptionService
{
    void ThrowExc(string message, int statusCode);
}