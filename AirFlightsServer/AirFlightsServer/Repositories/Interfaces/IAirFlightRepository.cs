
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface IAirFlightRepository
{
    Task<List<AirFlight>> GetAirFlightsAsync();
    Task AddAirFlightAsync(AirFlight model);
    Task DeleteAirFlightAsync(Guid id);

}