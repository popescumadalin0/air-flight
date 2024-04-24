using AirFlightsServer.Repositories.Interfaces;
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Repositories
{
    public class ReservationRepository: IReservationRepository
    {
        private readonly IContext _context;

        public ReservationRepository(IContext context)
        {
            _context = context;
        }
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            var reservation = await _context.Reservations.ToListAsync();

            return reservation;
        }

        public async Task AddReservationAsync(Reservation model)
        {
            await _context.Reservations.AddAsync(model);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteReservationAsync(Guid id)
        {
            var reservation = await _context.Reservations.SingleAsync(scp => scp.Id == id);
            _context.Reservations.Remove(reservation);

            await _context.SaveChangesAsync();

        }
    }
}
