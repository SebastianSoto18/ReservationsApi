using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservations.Domain.Models;

[Table("Users")]
public class User
{
    public User()
    {
        Reservations = new HashSet<Reservation>();
    }
    
    [Key]
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public virtual ICollection<Reservation>? Reservations { get; set; }
}