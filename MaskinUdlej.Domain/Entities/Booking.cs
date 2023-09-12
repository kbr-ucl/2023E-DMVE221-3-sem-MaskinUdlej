namespace MaskinUdlej.Domain.Entities;

public class Booking
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime StartDate { get; protected set; }
    public DateTime EndDate { get; protected set; }
    public List<Ressource> Ressources { get; protected set; }

    public Booking(List<Ressource> ressources, DateTime startDate, DateTime endDate, List<Booking> otherBookings)
    {
        Ressources = ressources;
        StartDate = startDate;
        EndDate = endDate;
        ValidateBooking(otherBookings);
        Ressources.ForEach(ressource => ressource.Bookings.Add(this));
    }


    public void Update(DateTime startDate, DateTime endDate, IEnumerable<Booking> otherBookings)
    {
        StartDate = startDate;
        EndDate = endDate;
        ValidateBooking(otherBookings);
    }

    protected void ValidateBooking(IEnumerable<Booking> otherBookings)
    {
        if(StartDate >= EndDate)
            throw new Exception("Start date must be before end date");

        if (Overlaps(otherBookings))
            throw new Exception("Booking overlaps with other bookings");
    }

    protected bool Overlaps(IEnumerable<Booking> otherBookings)
    {
        return otherBookings.Any(other => StartDate < other.EndDate && other.StartDate < EndDate);
    }
}