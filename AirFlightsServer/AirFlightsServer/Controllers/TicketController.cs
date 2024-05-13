using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.ResponseModels;
using AirFlightsServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AirFlightsServer.Controllers;

public class TicketController : BaseController
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAirFlightsAsync()
    {
        try
        {
            var result = await _ticketService.GetTicketsAsync();
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<Ticket>>(result.ToList()));

        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<Ticket>>(ex));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAirFlightAsync(string id)
    {
        try
        {
            var result = await _ticketService.GetTicketAsync(Guid.Parse(id));

            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<Ticket>(result));

        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<Ticket>(ex));
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAirFlightAsync(Ticket ticket)
    {
        try
        {
            await _ticketService.CreateTicketAsync(ticket);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAirFlightAsync(Ticket ticket)
    {
        try
        {
            await _ticketService.UpdateTicketAsync(ticket);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirFlightAsync(string id)
    {
        try
        { 
            await _ticketService.DeleteTicketAsync(Guid.Parse(id));
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }

}