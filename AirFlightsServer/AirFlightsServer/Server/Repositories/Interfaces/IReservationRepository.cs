using DataBaseLayout.Models;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/Interfaces/IReservationRepository.cs
namespace AirFlightsServer.Repositories.Interfaces
=======
namespace AirFlightsServer.Server.Repositories.Interfaces;

public interface IReservationRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/Interfaces/IReservationRepository.cs
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsAsync();
        Task AddReservationAsync(Reservation model);
        Task DeleteReservationAsync(Guid id);
    }
}
