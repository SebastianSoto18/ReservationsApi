using MediatR;
using Reservations.Application.Services;
using Reservations.Domain;

namespace Reservations.Application.Reservation.CreateReservation;

public class CreateReservationHandler(IReservationRepository reservationRepository, IExceptionService exceptionService, IPlaceRepository placeRepository) : IRequestHandler<CreateReservationCommand, long>
{
    public async Task<long> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var place = await placeRepository.GetByIdAsync(request.PlaceId, cancellationToken);
        
        if (place == null)
        {
            exceptionService.ThrowExc("El lugar no existe", 404);
        }

        if (!place.IsActive)
        {
            exceptionService.ThrowExc("El lugar no está activo", 400);
        }

        if (place.AvailableStartDate >= request.ReservationDate && place.AvailableEndDate <= request.ReservationDate)
        {
            exceptionService.ThrowExc("El lugar no está disponible en la fecha seleccionada", 400);
        }
        
        if(place.MinimumRentalHours > (request.CheckOutHour - request.CheckInHour).TotalHours)
        {
            exceptionService.ThrowExc("El lugar no puede ser reservado por menos de " + place.MinimumRentalHours + " horas", 400);
        }
        
        if(place.MaximumRentalHours < (request.CheckOutHour - request.CheckInHour).TotalHours)
        {
            exceptionService.ThrowExc("El lugar no puede ser reservado por más de " + place.MaximumRentalHours + " horas", 400);
        }
        
        var newReservation = new Domain.Models.Reservation
        {
            UserId = request.UserId,
            PlaceId = request.PlaceId,
            ReservationDate = request.ReservationDate,
            CheckInHour = request.CheckInHour,
            CheckOutHour = request.CheckOutHour,
            TotalPayment = request.TotalPayment
        };

        var userReservations =
            await reservationRepository.GetReservationsByUserIdAsync(request.UserId, cancellationToken);
        var placeReservations =
            await reservationRepository.GetReservationsByPlaceAsync(request.PlaceId, cancellationToken);

        if (userReservations.Any(r => newReservation.ReservationCrossing(r)))
        {
            exceptionService.ThrowExc("El usuario ya tiene una reserva en ese horario", 400);
        }
        
        if (placeReservations.Any(r => newReservation.ReservationCrossing(r)))
        {
            exceptionService.ThrowExc("El lugar ya tiene una reserva en ese horario", 400);
        }
        
        place.Reservations.Add(newReservation);
        await placeRepository.SaveChangesAsync(cancellationToken);
        
        return newReservation.ReservationId;
    }
}