using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface IRoleRepository
{
    Task<IList<Role>> GetRolesAsync();
    Task<Role> GetRoleAsync(string name);
    Task CreateRoleAsync(Role model);
    Task UpdateRoleAsync(Role model);
    Task DeleteRoleAsync(string name);
}