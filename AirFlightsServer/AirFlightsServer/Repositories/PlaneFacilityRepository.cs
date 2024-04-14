using AirFlightsServer.Repositories.Interfaces;
using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Repositories
{
    public class PlaneFacilityRepository: IPlaneFacilityRepository
    {
        private readonly IContext _context;

        public PlaneFacilityRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<PlaneFacility>> GetPlaneFacilitiesAsync()
        {
            var planeFacility = await _context.PlaneFacilities.ToListAsync();
            return planeFacility;

        }

        public async Task AddPlaneFacilityAsync(PlaneFacility model)
        {
            await _context.PlaneFacilities.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePlaneFacilityAsync(Guid id)
        {
            var planeFacility = await _context.PlaneFacilities.SingleAsync(scp => scp.Id == id);
            _context.PlaneFacilities.Remove(planeFacility);

            await _context.SaveChangesAsync();
        }

    }
}
