using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces
{
    public interface IAirFlightRepository
    {
        Task<List<AirFlight>> GetAirFlightAsync();
        Task AddAirFlight(AirFlight model);
        Task DeleteAirFlightAsync(Guid id);

    }
}
