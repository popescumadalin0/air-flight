using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout;

public class Context: DbContext, IContext
{
    public Context(DbContextOptions options)
        : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<PlaneSeat> PlaneSeats { get; set; }
    public DbSet<PlaneFacility> PlaneFacilities { get; set; }
    public DbSet<Layover> Layovers { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<AirFlight> AirFlights { get; set; }
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}