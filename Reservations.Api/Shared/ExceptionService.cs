using Reservations.Application.Services;

namespace Reservations.Api.Shared;

public class ExceptionService : IExceptionService
{
    public void ThrowExc(string message, int statusCode)
    {
        throw new ReservationException(message, statusCode);
    }
}