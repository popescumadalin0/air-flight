using Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace AirFlightsServer.Services.Interfaces;

public interface ILayoverService
{
    Task<IList<Layover>> GetLayoversAsync();
    Task<Layover> GetLayoverAsync(Guid id);
    Task AddLayoverAsync(Layover model);
    Task UpdateLayoverAsync(Layover model);
    Task DeleteLayoverAsync(Guid id);
}