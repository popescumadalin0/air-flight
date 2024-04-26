using DataBaseLayout.Models;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/Interfaces/ICompanyRepository.cs
namespace AirFlightsServer.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompaniesAsync();
        Task AddCompanyAsync(Company model);
        Task DeleteCompanyAsync(Guid  id);
    }
}
=======
namespace AirFlightsServer.Server.Repositories.Interfaces;

public interface ICompanyRepository
{
    Task<List<Company>> GetCompaniesAsync();
    Task AddCompanyAsync(Company model);
    Task DeleteCompanyAsync(Guid id);
}
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/Interfaces/ICompanyRepository.cs
