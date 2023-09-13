using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaskinUdlej.Domain.Entities;

public class Ressource
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public string Specification { get; protected set; }
    public double Pris { get; protected set; }
    public List<Booking> Bookings { get; protected set; } = new();
}