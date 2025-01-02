using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservations.Domain.Models;

[Table("UserRoles")]
public class UserRole
{
    [Key]
    public long UserRoleId { get; set; }
    [ForeignKey(nameof(User))]
    public long UserId { get; set; }
    [ForeignKey(nameof(Role))]
    public long RoleId { get; set; }
    
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}