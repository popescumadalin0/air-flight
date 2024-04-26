<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/PlaneFacilityRepository.cs
﻿using AirFlightsServer.Repositories.Interfaces;
=======
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/PlaneFacilityRepository.cs
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using DataBaseLayout.Context;
using AirFlightsServer.Server.Repositories.Interfaces;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/PlaneFacilityRepository.cs
namespace AirFlightsServer.Repositories
=======
namespace AirFlightsServer.Server.Repositories;

public class PlaneFacilityRepository : IPlaneFacilityRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/PlaneFacilityRepository.cs
{
    public class PlaneFacilityRepository: IPlaneFacilityRepository
    {
        private readonly IContext _context;

        public PlaneFacilityRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<PlaneFacility>> GetPlaneFacilitiesAsync()
        {
            var planeFacility = await _context.PlaneFacilities.ToListAsync();
            return planeFacility;

        }

        public async Task AddPlaneFacilityAsync(PlaneFacility model)
        {
            await _context.PlaneFacilities.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePlaneFacilityAsync(Guid id)
        {
            var planeFacility = await _context.PlaneFacilities.SingleAsync(scp => scp.Id == id);
            _context.PlaneFacilities.Remove(planeFacility);

            await _context.SaveChangesAsync();
        }

    }
}