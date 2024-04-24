using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface IPlaneSeatRepository
{
    Task<List<PlaneSeat>> GetPlaneSeatsAsync();
    Task AddPlaneSeatAsync(PlaneSeat model);
    Task DeletePlaneSeatAsync(Guid id);
}