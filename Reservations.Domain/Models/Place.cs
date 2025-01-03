using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservations.Domain.Models;

[Table("Places")]
public class Place
{
    public Place()
    {
        Reservations = new HashSet<Reservation>();
    }
    
    [Key]
    public long PlaceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Double PricePerHour { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime AvailableStartDate { get; set; }
    public DateTime AvailableEndDate { get; set; }
    public int MinimumRentalHours { get; set; }
    public int MaximumRentalHours { get; set; }
    
    public virtual ICollection<Reservation>? Reservations { get; set; }
}