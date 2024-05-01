using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace AirFlightsServer.Services.Interfaces;

public interface IUserService
{
    Task<IList<User>> GetUsersAsync();
    Task<User> GetUserAsync(string CNP);
    Task AddUserAsync(User model);
    Task UpdateUserAsync(User model);
    Task DeleteUserAsync(string CNP);
}