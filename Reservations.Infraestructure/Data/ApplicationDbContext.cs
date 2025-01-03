using Microsoft.EntityFrameworkCore;
using Reservations.Domain.Models;

namespace Reservations.Infraestructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Place> Places { get; set; }
}