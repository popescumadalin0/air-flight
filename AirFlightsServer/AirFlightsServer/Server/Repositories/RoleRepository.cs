<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/RoleRepository.cs
﻿using AirFlightsServer.Repositories.Interfaces;
=======
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Server.Repositories.Interfaces;
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/RoleRepository.cs
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/RoleRepository.cs
namespace AirFlightsServer.Repositories
=======
namespace AirFlightsServer.Server.Repositories;

public class RoleRepository : IRoleRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/RoleRepository.cs
{
    public class RoleRepository: IRoleRepository
    {
        private readonly IContext _context;

        public RoleRepository(IContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetRolesAsync()
        {
            var role = await _context.Roles.ToListAsync();

            return role;
        }

        public async Task CreateRoleAsync(Role model)
        {
            await _context.Roles.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(string name)
        {
            var role = await _context.Roles.SingleAsync(scp => scp.Name == name);
            _context.Roles.Remove(role);

            await _context.SaveChangesAsync();
        }
    }
}
