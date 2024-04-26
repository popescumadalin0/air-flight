<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/AirFlightRepository.cs
﻿using AirFlightsServer.Repositories.Interfaces;
=======
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Server.Repositories.Interfaces;
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/AirFlightRepository.cs
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/AirFlightRepository.cs
namespace AirFlightsServer.Repositories
=======
namespace AirFlightsServer.Server.Repositories;

public class AirFlightRepository : IAirFlightRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/AirFlightRepository.cs
{
    public class AirFlightRepository: IAirFlightRepository
    {
        private readonly IContext _context;

        public AirFlightRepository(IContext context)
        {
            _context = context;
        }
        public async Task<List<AirFlight>> GetAirFlightsAsync()
        {
            var airFlight = await _context.AirFlights.ToListAsync();
            return airFlight;

        }

        public async Task AddAirFlightAsync(AirFlight model)
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
