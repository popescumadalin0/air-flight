using DataBaseLayout.Models;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/Interfaces/IPlaneSeatRepository.cs
namespace AirFlightsServer.Repositories.Interfaces
=======
namespace AirFlightsServer.Server.Repositories.Interfaces;

public interface IPlaneSeatRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/Interfaces/IPlaneSeatRepository.cs
{
    public interface IPlaneSeatRepository
    {
        Task<List<PlaneSeat>> GetPlaneSeatsAsync();
        Task AddPlaneSeatAsync(PlaneSeat model);
        Task DeletePlaneSeatAsync(Guid id);
    }
}
