
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface ILayoverRepository
{
    Task<List<Layover>> GetLayoversAsync();
    Task AddLayoverAsync(Layover model);
    Task DeleteLayoverAsync(Guid id);
}