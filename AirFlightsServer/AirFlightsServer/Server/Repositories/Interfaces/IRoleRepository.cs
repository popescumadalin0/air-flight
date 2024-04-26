using DataBaseLayout.Models;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/Interfaces/IRoleRepository.cs
namespace AirFlightsServer.Repositories.Interfaces
=======
namespace AirFlightsServer.Server.Repositories.Interfaces;

public interface IRoleRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/Interfaces/IRoleRepository.cs
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRolesAsync();
        Task CreateRoleAsync(Role model);
        Task DeleteRoleAsync(string name);
    }
}
