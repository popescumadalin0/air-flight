using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout;

public interface IContext
{
   DbSet<User> Users { get; set; }
   DbSet<Role> Roles { get; set; }
   DbSet<Reservation> Reservations { get; set; }
   DbSet<PlaneSeat> PlaneSeats { get; set; }
   DbSet<PlaneFacility> PlaneFacilities { get; set; }
   DbSet<Layover> Layovers { get; set; }
   DbSet<Company> Companies { get; set; }
   DbSet<AirFlight> AirFlights { get; set; }
   Task<int> SaveChangesAsync();
}