﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace AirFlightsServer.Services.Interfaces;

public interface IPlaneFacilityService
{
    Task<IList<PlaneFacility>> GetPlaneFacilitiesAsync();
    Task<PlaneFacility> GetPlaneFacilityAsync(Guid id);
    Task AddPlaneFacilityAsync(PlaneFacility model);
    Task UpdatePlaneFacilityAsync(PlaneFacility model);
    Task DeletePlaneFacilityAsync(Guid id);
}