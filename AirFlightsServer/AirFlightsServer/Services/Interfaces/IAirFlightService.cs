using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace AirFlightsServer.Services.Interfaces;

public interface IAirFlightService
{
    Task<IList<AirFlightTicket>> GetAirFlightsAsync();

    Task<AirFlightTicket> GetAirFlightAsync(Guid id);

    Task CreateAirFlightAsync(AirFlightTicket airFlight);

    Task UpdateAirFlightAsync(AirFlightTicket  airFlight);

    Task DeleteAirFlightAsync(Guid id);
}