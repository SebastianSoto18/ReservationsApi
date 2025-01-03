namespace Reservations.Application.Reservation.GetReservationsByUser;

public class ReservationsDto
{
    public long ReservationId { get; set; }
    public DateTime ReservationDate { get; set; }
    public TimeSpan CheckInHour { get; set; }
    public TimeSpan CheckOutHour { get; set; }
    public Double TotalPayment { get; set; }
    public string PlaceName { get; set; } = string.Empty;
}