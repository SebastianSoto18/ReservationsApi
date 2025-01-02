namespace Reservations.Api.Shared;

public class ReservationException : Exception
{
    public int StatusCode { get; }
    
    public ReservationException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}