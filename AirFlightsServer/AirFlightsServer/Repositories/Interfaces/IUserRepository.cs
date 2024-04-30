using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IList<User>> GetUsersAsync();
    Task AddUserAsync(User model);
    Task DeleteUserAsync(string CNP);
}