using FluentValidation;
using MediatR;

namespace Reservations.Application.Reservation.GetReservationsByUser;

public record GetReservationsByUserQuery(long UserId, int? StartTime, int? EndTime, DateTime? Date) : IRequest<IReadOnlyCollection<ReservationsDto>>;


public class GetReservationsByUserQueryValidator : AbstractValidator<GetReservationsByUserQuery>
{
    public GetReservationsByUserQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty()
            .WithMessage("El id del usuario no puede estar vacío")
            .GreaterThan(0)
            .WithMessage("El id del usuario debe ser mayor a 0");

        RuleFor(x => x.StartTime).GreaterThan(0)
            .WithMessage("El tiempo de inicio debe ser mayor a 0")
            .When(x => x.StartTime is not null);
        
        RuleFor(x => x.EndTime).GreaterThan(0)
            .WithMessage("El tiempo de fin debe ser mayor a 0")
            .GreaterThan(x => x.StartTime)
            .WithMessage("El tiempo de fin debe ser mayor al tiempo de inicio")
            .When(x => x.EndTime is not null);
    }
}