using DataBaseLayout.Models;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/Interfaces/ILayoverRepository.cs
namespace AirFlightsServer.Repositories.Interfaces
=======
namespace AirFlightsServer.Server.Repositories.Interfaces;

public interface ILayoverRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/Interfaces/ILayoverRepository.cs
{
    public interface ILayoverRepository
    {
        Task<List<Layover>> GetLayoversAsync();
        Task AddLayoverAsync(Layover model);
        Task DeleteLayoverAsync(Guid id);
    }
}
