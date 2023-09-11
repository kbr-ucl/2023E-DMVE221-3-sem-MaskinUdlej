using MaskinUdlej.Domain.Entities;

namespace MaskinUdlej.Domain.Test.BookingTests;

public class BookingCreateAndUpdateTests
{
    [Fact]
    public void Given__Booking_With_StartDate_Before_EndDate__When_Creating_Booking__Then_Booking_Is_Created()
    {
        // Arrange
        var ressource = new Ressource();
        var startDate = DateTime.Now;
        var endDate = DateTime.Now.AddDays(1);

        // Act
        var booking = new Booking(ressource, startDate, endDate, new List<Booking>());

        // Assert
        Assert.NotNull(booking);
    }

    [Fact]
    public void Given__Booking_With_StartDate_After_EndDate__When_Creating_Booking__Then_Exception_Is_Thrown()
    {
        // Arrange
        var ressource = new Ressource();
        var endDate = DateTime.Now;
        var startDate = DateTime.Now.AddDays(1);

        // Act
        // Assert
        Assert.Throws<Exception>(() => new Booking(ressource, startDate, endDate, new List<Booking>()));
    }

    [Theory]
    [InlineData("2021-01-01", "2021-01-02", "2021-01-03", "2021-01-04")]
    public void Given__Booking_Is_Not_Overlapping_With_Other_Bookings__When_Creating_Booking__Then_Booking_Is_Created(
        string startDate, string endDate, string otherStartDate, string otherEndDate)
    {
        // Arrange
        var ressource = new Ressource();
        var otherBooking = new BookingStub();
        otherBooking.StartDate = DateTime.Parse(otherStartDate);
        otherBooking.EndDate = DateTime.Parse(otherEndDate);
        var otherBookings = new List<Booking> {otherBooking};


        // Act
        var booking = new Booking(ressource, DateTime.Parse(startDate), DateTime.Parse(endDate), otherBookings);

        // Assert
        Assert.NotNull(booking);
    }

    [Theory]
    [InlineData("2021-01-01", "2021-01-02", "2021-01-02", "2021-01-04")]
    public void Given__Booking_Is_Overlapping_With_Other_Bookings__When_Creating_Booking__Then_Exception_Is_Thrown(
        string startDate, string endDate, string otherStartDate, string otherEndDate)
    {
        // Arrange
        var ressource = new Ressource();
        var otherBooking = new BookingStub();
        otherBooking.StartDate = DateTime.Parse(otherStartDate);
        otherBooking.EndDate = DateTime.Parse(otherEndDate);
        var otherBookings = new List<Booking> {otherBooking};


        // Act
        var booking = new Booking(ressource, DateTime.Parse(startDate), DateTime.Parse(endDate), otherBookings);

        // Assert
        Assert.NotNull(booking);
    }
}