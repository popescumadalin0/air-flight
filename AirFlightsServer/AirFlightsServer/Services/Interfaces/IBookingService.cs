using Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace AirFlightsServer.Services.Interfaces;

public interface IBookingService
{
    Task<IList<Booking>> GetBookingsAsync();
    Task<Booking> GetBookingAsync(Guid id);
    Task AddBookingAsync(Booking model);
    Task UpdateBookingAsync(Booking model);
    Task DeleteBookingAsync(Guid id);
}