using Microsoft.EntityFrameworkCore;
using Reservations.Domain;
using Reservations.Domain.Models;

namespace Reservations.Infraestructure.Data.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public Task<User?> GetByEmailAsync(string email)
    {
        return context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<User?> GetByIdAsync(long id)
    {
       return context.Users.FirstOrDefaultAsync(u => u.UserId == id);
    }
}