using FluentValidation;
using MediatR;

namespace Reservations.Application.User.GetUserBasicInfo;

public record GetUserBasicInfoQuery (long UserId) : IRequest<UserBasicInfoDto>;

public class GetUserBasicInfoQueryValidator : AbstractValidator<GetUserBasicInfoQuery>
{
    public GetUserBasicInfoQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty()
            .WithMessage("El id del usuario no puede estar vacío")
            .GreaterThan(0)
            .WithMessage("El id del usuario debe ser mayor a 0");
    }
}

