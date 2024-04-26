using DataBaseLayout.Models;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/Interfaces/IPlaneFacilityRepository.cs
namespace AirFlightsServer.Repositories.Interfaces
=======
namespace AirFlightsServer.Server.Repositories.Interfaces;

public interface IPlaneFacilityRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/Interfaces/IPlaneFacilityRepository.cs
{
    public interface IPlaneFacilityRepository
    {
        Task<List<PlaneFacility>> GetPlaneFacilitiesAsync();
        Task AddPlaneFacilityAsync(PlaneFacility model);
        Task DeletePlaneFacilityAsync(Guid id);
    }
}
