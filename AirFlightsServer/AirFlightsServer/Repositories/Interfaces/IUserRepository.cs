using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IList<User>> GetUsersAsync();
    Task<User> GetUserAsync(string CNP);
    Task AddUserAsync(User model);
    Task UpdateUserAsync(User model);
    Task DeleteUserAsync(string CNP);
}