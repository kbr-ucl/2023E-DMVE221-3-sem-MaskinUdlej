using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaskinUdlej.Domain.Entities;

public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; protected set; }
    public DateTime StartDate { get; protected set; }
    public DateTime EndDate { get; protected set; }
    public List<Ressource> Ressources { get; protected set; }

    // Do not use !!!!  EF Core only
    public Booking()
    {
    }

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