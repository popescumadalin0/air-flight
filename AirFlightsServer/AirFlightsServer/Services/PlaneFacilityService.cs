using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Repositories;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;
using PlaneFacility =Models.PlaneFacility;


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
        var planeFacility= await _planeFacilityRepository.GetPlaneFacilitiesAsync();
        var response = planeFacility.Select(pf => new Models.PlaneFacility
        {
            Id = pf.Id,
            Name = pf.Name
        }).ToList();
        return response;
    }

    public async Task<PlaneFacility> GetPlaneFacilityAsync(Guid id)
    {
        var planeFacility = await _planeFacilityRepository.GetPlaneFacilityAsync(id);

        var response = new PlaneFacility()
        {
            Id = planeFacility.Id,
            Name = planeFacility.Name
        };

        return response;
    }

    public async Task AddPlaneFacilityAsync(PlaneFacility model)
    {
        var entity = new DataBaseLayout.Models.PlaneFacility()
        {
            Id = model.Id,
            Name = model.Name
        };
        await _planeFacilityRepository.AddPlaneFacilityAsync(entity);
    }

    public async Task UpdatePlaneFacilityAsync(PlaneFacility model)
    {
        var entity = new DataBaseLayout.Models.PlaneFacility()
        {
            Id = model.Id,
            Name = model.Name
        };
        await _planeFacilityRepository.UpdatePlaneFacilityAsync(entity);
    }

    public async Task DeletePlaneFacilityAsync(Guid id)
    {
        await _planeFacilityRepository.DeletePlaneFacilityAsync(id);
    }
}