<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/PlaneSeatRepository.cs
﻿using AirFlightsServer.Repositories.Interfaces;
=======
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Server.Repositories.Interfaces;
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/PlaneSeatRepository.cs
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/PlaneSeatRepository.cs
namespace AirFlightsServer.Repositories
=======
namespace AirFlightsServer.Server.Repositories;

public class PlaneSeatRepository : IPlaneSeatRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/PlaneSeatRepository.cs
{
    public class PlaneSeatRepository: IPlaneSeatRepository
    {
        private readonly IContext _context;
        public PlaneSeatRepository(IContext context)
        {
            _context = context;
        }
        public async Task<List<PlaneSeat>> GetPlaneSeatsAsync()
        {
            var planeSeat = await _context.PlaneSeats.ToListAsync();
            return planeSeat;
        }

        public async Task AddPlaneSeatAsync(PlaneSeat model)
        {
            await _context.PlaneSeats.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePlaneSeatAsync(Guid id)
        {
            var planeSeat = await _context.PlaneSeats.SingleAsync(scp => scp.Id == id);
            _context.PlaneSeats.Remove(planeSeat);

            await _context.SaveChangesAsync();
        }
    }
}
