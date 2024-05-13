using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Repositories.Interfaces;
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly IContext _context;

    public TicketRepository(IContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IList<Ticket>> GetTicketsAsync()
    {
        var airFlights = await _context.AirFlights.ToListAsync();
        return airFlights;

    }

    /// <inheritdoc />
    public async Task<Ticket> GetTicketAsync(Guid id)
    {
        var airFlight = await _context.AirFlights.FindAsync(id);

        return airFlight;
    }

    /// <inheritdoc />
    public async Task AddTicketAsync(Ticket model)
    {
        await _context.AirFlights.AddAsync(model);

        await _context.SaveChangesAsync();

    }

    /// <inheritdoc />
    public async Task UpdateTicketAsync(Ticket ticket)//todo: modificat
    {
        await _context.AirFlights.FindAsync(ticket);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteTicketAsync(Guid id)
    {
        var airFlighty = await _context.AirFlights.SingleAsync(scp => scp.Id == id);
        _context.AirFlights.Remove(airFlighty);

        await _context.SaveChangesAsync();
    }
}