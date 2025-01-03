namespace Reservations.Application.Place.GetAvailablePlaces;

public class AvailablePlace
{
    public long PlaceId { get; set; }
    public string PlaceName { get; set; } = string.Empty;
    public double PlacePrice { get; set; }
}