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
}