using MediatR;
using Reservations.Domain;

namespace Reservations.Application.Place.GetAvailablePlaces;

public class GetAvailablePlacesHandler(IPlaceRepository placeRepository): IRequestHandler<GetAvailablePlacesQuery, IReadOnlyCollection<AvailablePlace>>
{
    public async Task<IReadOnlyCollection<AvailablePlace>> Handle(GetAvailablePlacesQuery request, CancellationToken cancellationToken)
    {
        var places = await placeRepository.GetAvailablePlacesAsync(request.Date,request.StartTime,request.EndTime, cancellationToken);
        
        return (places.Select(x => new AvailablePlace
        {
            PlaceId = x.PlaceId,
            PlaceName = x.Name,
            PlacePrice = x.PricePerHour,
        })).ToList().AsReadOnly();
    }
}