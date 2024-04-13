using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces
{
    public interface IPlaneFacilityRepository
    {
        Task<List<PlaneFacility>> GetPlaneFacilitiesAsync();
        Task AddPlaneFacilities(PlaneFacility model);
        Task DeletePlaneFacilities(Guid id);
    }
}
