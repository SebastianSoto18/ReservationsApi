using MediatR;
using Reservations.Application.Services;
using Reservations.Domain;

namespace Reservations.Application.Reservation.DeleteReservation;

public class DeleteReservationHandler(IReservationRepository reservationRepository, IExceptionService exceptionService) : IRequestHandler<DeleteReservationCommand>
{
    public async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var userReservations = await reservationRepository.GetReservationsByUserIdAsync(request.UserId, cancellationToken);
        
        if(userReservations.All(x => x.ReservationId != request.ReservationId))
        {
            exceptionService.ThrowExc("La reserva no pertenece al usuario", 404);
        }
        
        var reservation = userReservations.First(x => x.ReservationId == request.ReservationId);
        reservationRepository.Delete(reservation);
        await reservationRepository.SaveChangesAsync(cancellationToken);
    }
}