using Microsoft.EntityFrameworkCore;
using Reservations.Domain;
using Reservations.Domain.Models;

namespace Reservations.Infraestructure.Data.Repositories;

public class PlaceRepository(ApplicationDbContext context) : IPlaceRepository
{
    public async Task<IReadOnlyCollection<Place>> GetAvailablePlacesAsync(DateTime date, TimeSpan checkInHour, TimeSpan checkOutHour, CancellationToken cancellationToken)
    {
        return await context.Places.Where(p => p.IsActive && p.AvailableStartDate <= date && p.AvailableEndDate >= date
            && (p.MinimumRentalHours <= checkOutHour.TotalHours - checkInHour.TotalHours) && (p.MaximumRentalHours >= checkOutHour.TotalHours - checkInHour.TotalHours)
            && !p.Reservations.Any(r => r.ReservationDate == date &&  ((r.CheckInHour > checkInHour && checkOutHour > r.CheckInHour &&checkOutHour <= r.CheckOutHour)
                || (r.CheckInHour <= checkInHour &&checkOutHour >= r.CheckInHour && checkOutHour <= r.CheckOutHour)
                || (r.CheckOutHour <=checkOutHour && checkInHour >= r.CheckInHour && checkInHour < r.CheckOutHour)
                || (r.CheckInHour >= checkInHour && r.CheckOutHour <=checkOutHour))))
            .ToListAsync(cancellationToken);
    }

    public Task<Place?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return context.Places.FirstOrDefaultAsync(p => p.PlaceId == id, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken); 
    }
}