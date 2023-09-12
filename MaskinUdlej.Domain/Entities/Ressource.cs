namespace MaskinUdlej.Domain.Entities;

public class Ressource
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public List<Booking> Bookings { get; protected set; } = new();
}