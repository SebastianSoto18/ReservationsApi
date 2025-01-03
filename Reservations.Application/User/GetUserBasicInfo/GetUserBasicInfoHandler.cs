using MediatR;
using Reservations.Application.Services;
using Reservations.Domain;

namespace Reservations.Application.User.GetUserBasicInfo;

public class GetUserBasicInfoHandler(IUserRepository userRepository, IExceptionService exceptionService) : IRequestHandler<GetUserBasicInfoQuery ,UserBasicInfoDto>
{
    public async Task<UserBasicInfoDto> Handle(GetUserBasicInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        
        if (user == null)
        {
            exceptionService.ThrowExc("Usuario no existe", 404);
        }
        
        return new UserBasicInfoDto
        {
            Name = user.Name,
            Email = user.Email
        };
    }
}