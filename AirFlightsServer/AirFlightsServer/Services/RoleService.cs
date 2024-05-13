using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Repositories;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;
using Models;

namespace AirFlightsServer.Services;

public class RoleService : IRoleService
{ 
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<IList<Role>> GetRolesAsync()
    {
        var role = await _roleRepository.GetRolesAsync();
        var response = role.Select(r => new Role()
        {
            Name = r.Name
        }).ToList();
        return response;
    }

    public async Task<Role> GetRoleAsync(string name)
    {
        var role = await _roleRepository.GetRoleAsync(name);
        var response = new Role()
        {
            Name = role.Name
        };
        return response;
    }

    public async Task CreateRoleAsync(Role model)
    {
        var entity = new DataBaseLayout.Models.Role()
        {
            Name = model.Name
        };
        await _roleRepository.CreateRoleAsync(entity);
    }

    public async Task UpdateRoleAsync(Role model)
    {
        var entity = new DataBaseLayout.Models.Role()
        {
            Name = model.Name
        };
        await _roleRepository.UpdateRoleAsync(entity);
    }

    public async Task DeleteRoleAsync(string name)
    {
        await _roleRepository.DeleteRoleAsync(name);
    }
}