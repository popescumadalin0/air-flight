using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface IBookingRepository
{
    Task<IList<Booking>> GetBookingsAsync();
    Task AddBookingAsync(Booking model);
    Task DeleteBookingAsync(Guid id);
}