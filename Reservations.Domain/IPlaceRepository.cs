using Reservations.Domain.Models;

namespace Reservations.Domain;

public interface IPlaceRepository
{
    Task<IReadOnlyCollection<Place>> GetAvailablePlacesAsync(DateTime date, TimeSpan checkInHour, TimeSpan checkOutHour, CancellationToken cancellationToken);
    Task<Place?> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}