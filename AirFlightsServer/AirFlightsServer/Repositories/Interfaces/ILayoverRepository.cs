using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface ILayoverRepository
{
    Task<IList<Layover>> GetLayoversAsync();
    Task<Layover> GetLayoverAsync(Guid id);
    Task AddLayoverAsync(Layover model);
    Task UpdateLayoverAsync(Layover model);
    Task DeleteLayoverAsync(Guid id);
}