using DataBaseLayout.Models;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/Interfaces/IAirFlightRepository.cs
namespace AirFlightsServer.Repositories.Interfaces
=======
namespace AirFlightsServer.Server.Repositories.Interfaces;

public interface IAirFlightRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/Interfaces/IAirFlightRepository.cs
{
    public interface IAirFlightRepository
    {
        Task<List<AirFlight>> GetAirFlightsAsync();
        Task AddAirFlightAsync(AirFlight model);
        Task DeleteAirFlightAsync(Guid id);

    }
}
