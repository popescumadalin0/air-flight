using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace AirFlightsServer.Services.Interfaces;

public interface IPlaneSeatService
{
    Task<IList<PlaneSeat>> GetPlaneSeatsAsync();
    Task<PlaneSeat> GetPlaneSeatAsync(Guid id);
    Task AddPlaneSeatAsync(PlaneSeat model);
    Task UpdatePlaneSeatAsync(PlaneSeat model);
    Task DeletePlaneSeatAsync(Guid id);
}