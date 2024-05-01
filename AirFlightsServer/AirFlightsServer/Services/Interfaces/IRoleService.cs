using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace AirFlightsServer.Services.Interfaces;

public interface IRoleService
{
    Task<IList<Role>> GetRolesAsync();
    Task<Role> GetRoleAsync(string name);
    Task CreateRoleAsync(Role model);
    Task UpdateRoleAsync(Role model);
    Task DeleteRoleAsync(string name);
}