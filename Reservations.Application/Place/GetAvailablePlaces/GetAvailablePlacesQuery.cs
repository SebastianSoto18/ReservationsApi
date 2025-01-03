using FluentValidation;
using MediatR;

namespace Reservations.Application.Place.GetAvailablePlaces;

public record GetAvailablePlacesQuery(TimeSpan StartTime, TimeSpan EndTime, DateTime Date) : IRequest<IReadOnlyCollection<AvailablePlace>>;

public class GetAvailablePlacesQueryValidator : AbstractValidator<GetAvailablePlacesQuery>
{
    public GetAvailablePlacesQueryValidator()
    {
        RuleFor(x => x.StartTime).NotEmpty()
            .WithMessage("La hora de inicio no puede estar vacía")
            .LessThan(x => x.EndTime)
            .WithMessage("La hora de inicio debe ser menor a la hora de fin");
        RuleFor(x => x.EndTime).NotEmpty()
            .WithMessage("La hora de fin no puede estar vacía");
        RuleFor(x => x.Date).NotEmpty()
            .WithMessage("La fecha no puede estar vacía");
    }
}