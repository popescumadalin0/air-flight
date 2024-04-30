using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;
using DataBaseLayout.Models;
using Models;

namespace AirFlightsServer.Services;

public class AirFlightService : IAirFlightService
{
    private readonly IAirFlightRepository _airFlightRepository;

    public AirFlightService(IAirFlightRepository airFlightRepository)
    {
        _airFlightRepository = airFlightRepository;
    }
    public async Task<IList<AirFlightTicket>> GetAirFlightsAsync()
    {
        var airFlight = await _airFlightRepository.GetAirFlightsAsync();

        var response = airFlight.Select(af => new AirFlightTicket()
        {
            Currency = af.Currency,
            Id = af.Id,
            Price = af.Price
        }).ToList();

        return response;

    }

    public async Task<AirFlightTicket> GetAirFlightAsync(Guid id)
    {
        var airFlight = await _airFlightRepository.GetAirFlightAsync(id);

        var response = new AirFlightTicket()
        {
            Currency = airFlight.Currency,
            Id = airFlight.Id,
            Price = airFlight.Price
        };

        return response;
    }

    public async Task CreateAirFlightAsync(AirFlightTicket model)
    {
        var entity = new AirFlight()
        {
            Currency = model.Currency,
            Id = model.Id,
            Price = model.Price,
            //todo: sa vedem daca le adaugam de aici
            //Layovers = 
        };
        await _airFlightRepository.AddAirFlightAsync(entity);
    }

    public async Task UpdateAirFlightAsync(AirFlightTicket airFlight)//janina
    {
        var entity = new AirFlight()
        {
            Currency = airFlight.Currency,
            Id = airFlight.Id,
            Price = airFlight.Price,
            //todo: sa vedem daca le adaugam de aici
            //Layovers = 
        };
        await _airFlightRepository.UpdateAirFlightAsync(entity);
    }

    public async Task DeleteAirFlightAsync(Guid id)
    {
        await _airFlightRepository.DeleteAirFlightAsync(id);
    }

}