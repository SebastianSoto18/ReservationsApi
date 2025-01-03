using FluentValidation;
using MediatR;

namespace Reservations.Application.Reservation.DeleteReservation;

public class DeleteReservationCommand : IRequest
{
    public long ReservationId { get; set; }
    public long UserId { get; set; }
}

public class DeleteReservationCommandValidator : AbstractValidator<DeleteReservationCommand>
{
    public DeleteReservationCommandValidator()
    {
        RuleFor(x => x.ReservationId).NotEmpty()
            .WithMessage("El id de la reserva no puede estar vacío")
            .GreaterThan(0)
            .WithMessage("El id de la reserva debe ser mayor a 0");
        
        RuleFor(x => x.UserId).NotEmpty()
            .WithMessage("El id del usuario no puede estar vacío")
            .GreaterThan(0)
            .WithMessage("El id del usuario debe ser mayor a 0");
    }
}