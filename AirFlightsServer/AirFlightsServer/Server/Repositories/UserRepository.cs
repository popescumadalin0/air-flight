<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/UserRepository.cs
﻿using AirFlightsServer.Repositories.Interfaces;
=======
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Server.Repositories.Interfaces;
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/UserRepository.cs
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/UserRepository.cs
namespace AirFlightsServer.Repositories
=======
namespace AirFlightsServer.Server.Repositories;

public class UserRepository : IUserRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/UserRepository.cs
{
    public class UserRepository:IUserRepository
    {
        private readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsersAsync()
        {
            var user = await _context.Users.ToListAsync();

            return user;

        }

        public async Task AddUserAsync(User model)
        {
            await _context.Users.AddAsync(model);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteUserAsync(string CNP)
        {
            var user = await _context.Users.SingleAsync(scp => scp.CNP == CNP);
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

        }
    }
}
