using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsAsync();
        Task AddReservations(Reservation model);
        Task DeleteReservations(Guid id);
    }
}
