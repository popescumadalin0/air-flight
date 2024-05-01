using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Repositories.Interfaces;
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IContext _context;

    public RoleRepository(IContext context)
    {
        _context = context;
    }
    public async Task<IList<Role>> GetRolesAsync()
    {
        var role = await _context.Roles.ToListAsync();

        return role;
    }

    public async Task<Role> GetRoleAsync(string name)
    {
        var role = await _context.Roles.FindAsync(name);

        return role;
    }

    public async Task CreateRoleAsync(Role model)
    {
        await _context.Roles.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateRoleAsync(Role model)
    {
        await _context.Roles.FindAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(string name)
    {
        var role = await _context.Roles.SingleAsync(scp => scp.Name == name);
        _context.Roles.Remove(role);

        await _context.SaveChangesAsync();
    }
}