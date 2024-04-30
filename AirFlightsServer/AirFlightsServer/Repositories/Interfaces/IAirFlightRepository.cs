using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface IAirFlightRepository
{
    Task<IList<AirFlight>> GetAirFlightsAsync();
    Task<AirFlight> GetAirFlightAsync(Guid id);
    Task AddAirFlightAsync(AirFlight model);
    Task UpdateAirFlightAsync(AirFlight  airFlight);
    Task DeleteAirFlightAsync(Guid id);
}