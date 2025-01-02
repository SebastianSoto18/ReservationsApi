using Microsoft.EntityFrameworkCore;
using Reservations.Domain;
using Reservations.Domain.Models;

namespace Reservations.Infraestructure.Data.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;
    
    public Task<User?> GetByEmailAsync(string email)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}