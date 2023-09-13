using MaskinUdlej.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaskinUdlej.Api
{
    public class MaskinUdlejContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ressource> Ressources { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<BookingRessource> BookingRessources { get; set; }

        public MaskinUdlejContext(DbContextOptions<MaskinUdlejContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookingRessource>()
        //        .HasKey(br => new { br.BookingId, br.RessourceId });

        //    modelBuilder.Entity<BookingRessource>()
        //        .HasOne(br => br.Booking)
        //        .WithMany(b => b.BookingRessources)
        //        .HasForeignKey(br => br.BookingId);

        //    modelBuilder.Entity<BookingRessource>()
        //        .HasOne(br => br.Ressource)
        //        .WithMany(r => r.BookingRessources)
        //        .HasForeignKey(br => br.RessourceId);
        //}
    }
}
