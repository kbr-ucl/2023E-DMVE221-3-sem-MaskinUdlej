using MaskinUdlej.Domain.Entities;

namespace MaskinUdlej.Domain.Test.BookingTests;

internal class BookingStub : Booking
{
    public BookingStub(Ressource ressource, DateTime startDate, DateTime endDate,
        IEnumerable<Booking> otherBookings) : base(ressource, startDate, endDate, otherBookings)
    {
    }

    public BookingStub() : base(new Ressource(), DateTime.Now, DateTime.Now.AddDays(1), new List<Booking>())
    {
    }

    public new DateTime StartDate
    {
        get { return base.StartDate; }
        set { base.StartDate = value; }
    }

    public new DateTime EndDate
    {
        get { return base.EndDate; }
        set { base.EndDate = value; }
    }
}