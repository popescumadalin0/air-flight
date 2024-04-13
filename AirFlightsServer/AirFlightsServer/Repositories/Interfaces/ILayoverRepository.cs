using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces
{
    public interface ILayoverRepository
    {
        Task<List<Layover>> GetLayoversAsync();
        Task AddLayover(Layover model);
        Task DeleteLayover(Guid id);
    }
}
