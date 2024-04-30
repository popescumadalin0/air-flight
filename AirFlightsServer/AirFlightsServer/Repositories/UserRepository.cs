using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Repositories.Interfaces;
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IContext _context;

    public UserRepository(IContext context)
    {
        _context = context;
    }
    public async Task<IList<User>> GetUsersAsync()
    {
        var user = await _context.Users.ToListAsync();

        return user;

    }

    public async Task<User> GetUserAsync(string CNP)
    {
        throw new System.NotImplementedException();
    }

    public async Task AddUserAsync(User model)
    {
        await _context.Users.AddAsync(model);

        await _context.SaveChangesAsync();

    }

    public async Task UpdateUserAsync(User model)
    {
        await _context.Users.FindAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(string CNP)
    {
        var user = await _context.Users.SingleAsync(scp => scp.CNP == CNP);
        _context.Users.Remove(user);

        await _context.SaveChangesAsync();

    }
}