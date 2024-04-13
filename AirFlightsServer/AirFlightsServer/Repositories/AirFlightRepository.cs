﻿using AirFlightsServer.Repositories.Interfaces;
using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Repositories
{
    public class AirFlightRepository: IAirFlightRepository
    {
        private readonly IContext _context;

        public AirFlightRepository(IContext context)
        {
            _context = context;
        }
        public async Task<List<AirFlight>> GetAirFlightAsync()
        {
            var airFlight = await _context.AirFlights.ToListAsync();
            return airFlight;

        }

        public async Task AddAirFlight(AirFlight model)
        {
            await _context.AirFlights.AddAsync(model);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAirFlightAsync(Guid id)
        {
            var airFlighty = await _context.AirFlights.SingleAsync(scp => scp.Id == id);
            _context.AirFlights.Remove(airFlighty);

            await _context.SaveChangesAsync();
        }

    }
}
