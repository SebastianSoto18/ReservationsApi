using Microsoft.EntityFrameworkCore;
using Reservations.Domain;
using Reservations.Domain.Models;

namespace Reservations.Infraestructure.Data.Repositories;

public class ReservationRepository(ApplicationDbContext context) : IReservationRepository
{
    public async Task<IReadOnlyCollection<Reservation>> GetReservationsAsync(int? startTime, int? endTime, DateTime? reservationDate, long userId,
        CancellationToken cancellationToken)
    {
        return await context.Reservations.Include(r => r.Place)
            .Where(r => r.UserId == userId && (startTime == null || r.CheckInHour <= TimeSpan.FromHours(startTime.Value)) && 
                        (endTime == null || r.CheckOutHour >= TimeSpan.FromHours(endTime.Value)) &&
                        (reservationDate == null || r.ReservationDate == reservationDate))
            .ToListAsync(cancellationToken);
    }
}