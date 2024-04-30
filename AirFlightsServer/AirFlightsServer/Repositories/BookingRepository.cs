using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Repositories.Interfaces;
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly IContext _context;

    public BookingRepository(IContext context)
    {
        _context = context;
    }
    public async Task<IList<Booking>> GetBookingsAsync()
    {
        var bookings = await _context.Booking.ToListAsync();

        return bookings;
    }

    public async Task AddBookingAsync(Booking model)
    {
        await _context.Booking.AddAsync(model);

        await _context.SaveChangesAsync();

    }

    public async Task DeleteBookingAsync(Guid id)
    {
        var reservation = await _context.Booking.SingleAsync(scp => scp.Id == id);
        _context.Booking.Remove(reservation);

        await _context.SaveChangesAsync();

    }
}