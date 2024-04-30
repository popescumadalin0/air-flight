using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Repositories;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Models;

namespace AirFlightsServer.Services
{
    public class BookingService: IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IList<Booking>> GetBookingsAsync()
        {
            var booking = await _bookingRepository.GetBookingsAsync();

            var response = booking.Select(b => new Booking()
            {
                Id = b.Id,
            }).ToList();

            return response;
        }

        public async Task<Booking> GetBookingAsync(Guid id)
        {
            var booking = await _bookingRepository.GetBookingAsync(id);

            var response = new Booking()
            {
                Id = booking.Id
            };

            return response;
        }

        public async Task AddBookingAsync(Booking model)
        {
            var entity = new DataBaseLayout.Models.Booking()
            {
                Id = model.Id
            };
            await _bookingRepository.AddBookingAsync(entity);
        }

        public async Task DeleteBookingAsync(Guid id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
        }
    }
}
