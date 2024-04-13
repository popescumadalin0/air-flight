using AirFlightsServer.Repositories.Interfaces;
using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Repositories
{
    public class LayoverRepository : ILayoverRepository
    {
        private readonly IContext _context;

        public LayoverRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<Layover>> GetLayoversAsync()
        {
            var layover = await _context.Layovers.ToListAsync();
            return layover;

        }

        public async Task AddLayover(Layover model)
        {
            await _context.Layovers.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteLayover(Guid id)
        {
            var layover = await _context.Layovers.SingleAsync(scp => scp.Id == id);
            _context.Layovers.Remove(layover);

            await _context.SaveChangesAsync();
        }
    }
}
