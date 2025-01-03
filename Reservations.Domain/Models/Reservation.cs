using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservations.Domain.Models;

[Table("Reservations")]
public class Reservation
{
    [Key]
    public long ReservationId { get; set; }
    public DateTime ReservationDate { get; set; }
    public TimeSpan CheckInHour { get; set; }
    public TimeSpan CheckOutHour { get; set; }
    [ForeignKey(nameof(User))]
    public long UserId { get; set; }
    [ForeignKey(nameof(Place))]
    public long PlaceId { get; set; }
    public Double TotalPayment { get; set; }
    
    public virtual User User { get; set; } = null!;
    public virtual Place Place { get; set; } = null!;
    
    
    public bool ReservationCrossing (Reservation registeredReservation)
    {
        if (registeredReservation.ReservationDate.Date != ReservationDate.Date)
        {
            return false;
        }

        return FoundCrossingOfHours(registeredReservation);
    }

    private bool FoundCrossingOfHours(Reservation registered)
    {
        return (CheckInHour > registered.CheckInHour && registered.CheckOutHour > CheckInHour && registered.CheckOutHour <= CheckOutHour)
               || (CheckInHour <= registered.CheckInHour && registered.CheckOutHour >= CheckInHour && registered.CheckOutHour <= CheckOutHour)
               || (CheckOutHour <= registered.CheckOutHour && registered.CheckInHour >= CheckInHour && registered.CheckInHour < CheckOutHour)
               || (CheckInHour >= registered.CheckInHour && CheckOutHour <= registered.CheckOutHour);
    }
}