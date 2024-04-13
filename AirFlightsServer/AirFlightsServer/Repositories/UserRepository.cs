﻿using AirFlightsServer.Repositories.Interfaces;
using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Repositories
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

        public async Task AddUsers(User model)
        {
            await _context.Users.AddAsync(model);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteUsers(string CNP)
        {
            var user = await _context.Users.SingleAsync(scp => scp.CNP == CNP);
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

        }
    }
}
