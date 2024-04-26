<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/LayoverRepository.cs
﻿using AirFlightsServer.Repositories.Interfaces;
=======
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/LayoverRepository.cs
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using DataBaseLayout.Context;
using AirFlightsServer.Server.Repositories.Interfaces;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/LayoverRepository.cs
namespace AirFlightsServer.Repositories
=======
namespace AirFlightsServer.Server.Repositories;

public class LayoverRepository : ILayoverRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/LayoverRepository.cs
{
    public class LayoverRepository : ILayoverRepository
    {
        private readonly IContext _context;

        public LayoverRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<Layover>> GetLayoversAsync()
        {
            var layover = await _context.Layovers.ToListAsync();
            return layover;

        }

        public async Task AddLayoverAsync(Layover model)
        {
            await _context.Layovers.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteLayoverAsync(Guid id)
        {
            var layover = await _context.Layovers.SingleAsync(scp => scp.Id == id);
            _context.Layovers.Remove(layover);

            await _context.SaveChangesAsync();
        }
    }
}
