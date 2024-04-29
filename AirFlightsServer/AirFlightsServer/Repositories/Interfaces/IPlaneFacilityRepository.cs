using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface IPlaneFacilityRepository
{
    Task<List<PlaneFacility>> GetPlaneFacilitiesAsync();
    Task AddPlaneFacilityAsync(PlaneFacility model);
    Task DeletePlaneFacilityAsync(Guid id);
}