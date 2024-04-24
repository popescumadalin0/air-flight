using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface IReservationRepository
{
    Task<List<Reservation>> GetReservationsAsync();
    Task AddReservationAsync(Reservation model);
    Task DeleteReservationAsync(Guid id);
}