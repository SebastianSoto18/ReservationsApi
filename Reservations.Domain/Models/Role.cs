using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservations.Domain.Models;

[Table("Roles")]
public class Role
{
    [Key]
    public long RoleId { get; set; }
    public string Name { get; set; }
}