using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Models;
using AirFlightsServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AirFlightsServer.Controllers;

public class AirFlightController : BaseController
{
    private readonly IAirFlightService _airFlightService;

    public AirFlightController(IAirFlightService airFlightService)
    {
        _airFlightService = airFlightService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAirFlightsAsync()
    {
        try
        {
            var result = await _airFlightService.GetAirFlightsAsync();
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<AirFlightTicket>>(result.ToList()));

        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<AirFlightTicket>>(ex));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAirFlightAsync(string id)
    {
        try
        {
            var result = await _airFlightService.GetAirFlightAsync(Guid.Parse(id));

            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<AirFlightTicket>(result));

        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<AirFlightTicket>(ex));
        }
    }

    [HttpPost]//janina
    public async Task<IActionResult> CreateAirFlightAsync(AirFlightTicket airFlightTicket)
    {
        try
        {
            await _airFlightService.CreateAirFlightAsync(airFlightTicket);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAirFlightAsync(AirFlightTicket airFlightTicket)
    {
        try
        {
            await _airFlightService.UpdateAirFlightAsync(airFlightTicket);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirFlight(string id)
    {
        try
        { 
            await _airFlightService.DeleteAirFlightAsync(Guid.Parse(id));
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }

}