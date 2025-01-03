using FluentValidation;
using MediatR;

namespace Reservations.Application.Reservation.CreateReservation;

public class CreateReservationCommand : IRequest<long>
{
    public long PlaceId { get; set; }
    public long UserId { get; set; }
    public DateTime ReservationDate { get; set; }
    public TimeSpan CheckInHour { get; set; }
    public TimeSpan CheckOutHour { get; set; }
    public Double TotalPayment { get; set; }
}

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.PlaceId).GreaterThan(0)
            .WithMessage("El id del lugar no puede estar vacío")
            .WithMessage("El id del lugar debe ser mayor a 0");
        
        RuleFor(x => x.ReservationDate).NotEmpty()
            .WithMessage("La fecha de la reserva no puede estar vacía");
        
        RuleFor(x => x.CheckInHour).NotEmpty()
            .WithMessage("La hora de entrada no puede estar vacía")
            .LessThan(x => x.CheckOutHour)
            .WithMessage("La hora de entrada debe ser menor a la hora de salida");
        
        RuleFor(x => x.CheckOutHour).NotEmpty()
            .WithMessage("La hora de salida no puede estar vacía")
            .GreaterThan(x => x.CheckInHour)
            .WithMessage("La hora de salida debe ser mayor a la hora de entrada");
        RuleFor(x => x.TotalPayment).GreaterThan(0)
            .WithMessage("El pago total debe ser mayor a 0");
    }
}