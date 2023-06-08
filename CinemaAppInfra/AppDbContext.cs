using CinemaApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppInfra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Screen> Screen { get; set; }
    }

}
