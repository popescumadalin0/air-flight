using System.Security.Cryptography;
using System.Threading.Tasks;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Context;

public class Context : DbContext, IContext
{
    public Context(DbContextOptions options)
        : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<PlaneSeat> PlaneSeats { get; set; }
    public DbSet<PlaneFacility> PlaneFacilities { get; set; }
    public DbSet<Layover> Layovers { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<AirFlight> AirFlights { get; set; }
    public async Task<int> SaveChangesAsync()
    {
        
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<AirFlight>()
        //     .Navigation(a => a.Layovers)
        //     .AutoInclude();
    //
    //     base.OnModelCreating(modelBuilder);
    //
    //     foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    //     {
    //         foreach (var navigation in entityType.GetNavigations())
    //         {
    //             modelBuilder.Entity(entityType.ClrType)
    //                 .Navigation(navigation.Name)
    //                 .AutoInclude();
    //         }
    //     }
    }
}