using Reservations.Domain.Models;

namespace Reservations.Domain;

public interface IReservationRepository
{
    Task<IReadOnlyCollection<Reservation>> GetReservationsAsync(int? startTime, int? endTime, DateTime? reservationDate, long userId, CancellationToken cancellationToken);
}