using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;
using Models;
using PlaneFacility = DataBaseLayout.Models.PlaneFacility;


namespace AirFlightsServer.Services;

public class PlaneFacilityService: IPlaneFacilityService
{
    private readonly IPlaneFacilityRepository _planeFacilityRepository;

    public PlaneFacilityService(IPlaneFacilityRepository planeFacilityRepository)
    {
        _planeFacilityRepository = planeFacilityRepository;
    }

    public async Task<IList<PlaneFacility>> GetPlaneFacilitiesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<PlaneFacility> GetPlaneFacilityAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddPlaneFacilityAsync(PlaneFacility model)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePlaneFacilityAsync(PlaneFacility model)
    {
        throw new NotImplementedException();
    }

    public async Task DeletePlaneFacilityAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}