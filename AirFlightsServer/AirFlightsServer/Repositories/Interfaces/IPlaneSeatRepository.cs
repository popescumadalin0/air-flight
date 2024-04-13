using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces
{
    public interface IPlaneSeatRepository
    {
        Task<List<PlaneSeat>> GetPlaneSeatsAsync();
        Task AddPlaneSeats(PlaneSeat model);
        Task DeletePlaneSeats(Guid id);
    }
}
