using Reservations.Domain.Models;
using Reservations.Infraestructure;
using Assert = NUnit.Framework.Assert;

namespace ReservationTest;

[TestFixture]
public class CrossingInReservations
{
    [Test]
    [TestCase(true, "01/08/2024", "08:30", "09:30")]
    [TestCase(true, "01/08/2024", "08:30", "12:00")]
    [TestCase(true, "01/08/2024", "06:00", "09:00")]
    [TestCase(true, "01/08/2024", "09:00", "12:00")]
    [TestCase(false,"01/08/2024", "11:00", "12:00")]
    [TestCase(false,"01/08/2024", "06:00", "08:00")]
    [TestCase(false,"02/08/2024", "08:00", "10:00")]
    [TestCase(false,"01/02/2024", "08:00", "10:00")]
    public void GetCrossingClassSessions_Should_Pass(bool crossing, string date, string startTime, string endTime)
    {
        // Arrange
        var baseReservation = new Reservation
        {
            ReservationDate = new DateTime(2024, 12, 15),
            CheckInHour = new TimeSpan(8, 0, 0),
            CheckOutHour = new TimeSpan(10, 0, 0)
        };

        var newReservation= new Reservation
        {
            ReservationDate = date.ParseDate(),
            CheckInHour = startTime.ParseHour(),
            CheckOutHour = endTime.ParseHour()
        };


        //act
        var result = baseReservation.ReservationCrossing(newReservation);


        //Assert
        Assert.That(result, Is.EqualTo(crossing));
    }
}