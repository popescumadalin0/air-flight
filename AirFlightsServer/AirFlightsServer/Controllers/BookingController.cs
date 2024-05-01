using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.ResponseModels;
using AirFlightsServer.Services;
using AirFlightsServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace AirFlightsServer.Controllers;

public class BookingController:BaseController
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<IActionResult>GetBookingsAsync()
    {
        try
        {
            var result = await _bookingService.GetBookingsAsync();
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<Booking>>(result.ToList()));

        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<Booking>>(ex));
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingAsync(string id)
    {
        try
        {
            var result = await _bookingService.GetBookingAsync(Guid.Parse(id));

            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<Booking>(result));

        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<Booking>(ex));
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookingAsync(Booking booking)
    {
        try
        {
            await _bookingService.AddBookingAsync(booking);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBookingAsync(Booking booking)
    {
        try
        {
            await _bookingService.UpdateBookingAsync(booking);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookingAsync(string id)
    {
        try
        {
            await _bookingService.DeleteBookingAsync(Guid.Parse(id));
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }
}