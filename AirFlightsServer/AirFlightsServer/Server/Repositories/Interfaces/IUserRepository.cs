using DataBaseLayout.Models;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/Interfaces/IUserRepository.cs
namespace AirFlightsServer.Repositories.Interfaces
=======
namespace AirFlightsServer.Server.Repositories.Interfaces;

public interface IUserRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/Interfaces/IUserRepository.cs
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task AddUserAsync(User model);
        Task DeleteUserAsync(string CNP);
    }
}
