using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DataBaseLayout.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Context;

public class Context : IdentityDbContext<User, Role, string>, IContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<PlaneSeat> PlaneSeats { get; set; }
    public DbSet<PlaneFacility> PlaneFacilities { get; set; }
    public DbSet<Layover> Layovers { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<AirFlight> AirFlights { get; set; }

    public Context(DbContextOptions<Context> options)
        : base(options) { }

    public async Task<int> SaveChangesAsync()
    {

        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(name: "Users");
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable(name: "Roles");
        });
        modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable(name: "UserClaims");
        });
        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable(name: "UserRoles");
        });
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable(name: "RoleClaims");
        });
        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable(name: "UserTokens");
        });
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable(name: "UserLogins");
        });

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