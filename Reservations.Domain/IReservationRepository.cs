using Reservations.Domain.Models;

namespace Reservations.Domain;

public interface IReservationRepository
{
    Task<IReadOnlyCollection<Reservation>> GetReservationsAsync(int? startTime, int? endTime, DateTime? reservationDate, long userId, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Reservation>> GetReservationsByPlaceAsync(long placeId, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Reservation>> GetReservationsByUserIdAsync(long userId, CancellationToken cancellationToken);
    void Delete(Reservation reservation);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}