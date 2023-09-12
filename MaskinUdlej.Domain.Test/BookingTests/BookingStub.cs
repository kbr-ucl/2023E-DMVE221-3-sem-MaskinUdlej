using MaskinUdlej.Domain.Entities;

namespace MaskinUdlej.Domain.Test.BookingTests;

internal class BookingStub : Booking
{
    public BookingStub(List<Ressource> ressources, DateTime startDate, DateTime endDate,
        List<Booking> otherBookings) : base(ressources, startDate, endDate, otherBookings)
    {
    }

    public BookingStub() : base(new List<Ressource>(), DateTime.Now, DateTime.Now.AddDays(1), new List<Booking>())
    {
    }

    public new DateTime StartDate
    {
        get => base.StartDate;
        set => base.StartDate = value;
    }

    public new DateTime EndDate
    {
        get => base.EndDate;
        set => base.EndDate = value;
    }
}