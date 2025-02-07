﻿using Reservations.Domain.Models;

namespace Reservations.Domain;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(long id);
}