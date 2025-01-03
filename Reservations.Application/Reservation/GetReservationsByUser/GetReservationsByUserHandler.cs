using MediatR;
using Reservations.Domain;

namespace Reservations.Application.Reservation.GetReservationsByUser;

public class GetReservationsByUserHandler(IReservationRepository reservationRepository) : IRequestHandler<GetReservationsByUserQuery, IReadOnlyCollection<ReservationsDto>>
{
    public async Task<IReadOnlyCollection<ReservationsDto>> Handle(GetReservationsByUserQuery request, CancellationToken cancellationToken)
    {
        var data = await reservationRepository.GetReservationsAsync(request.StartTime, request.EndTime, request.Date, request.UserId, cancellationToken);
        
        return data.Select(x => new ReservationsDto
        {
            ReservationId = x.ReservationId,
            ReservationDate = x.ReservationDate,
            CheckInHour = x.CheckInHour,
            CheckOutHour = x.CheckOutHour,
            PlaceName = x.Place.Name,
            TotalPayment = x.TotalPayment
        }).ToList();
    }
}