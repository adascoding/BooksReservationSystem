using BooksReservationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksReservationAPI.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    public DbSet<Book> Books { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DataSeeder.Seed(modelBuilder);
    }
}
