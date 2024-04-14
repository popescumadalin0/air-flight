using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces
{
    public interface ILayoverRepository
    {
        Task<List<Layover>> GetLayoversAsync();
        Task AddLayoverAsync(Layover model);
        Task DeleteLayoverAsync(Guid id);
    }
}
