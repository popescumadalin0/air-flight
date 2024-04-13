using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompaniesAsync();
        Task AddCompanies(Company model);
        Task DeleteCompanies(Guid  id);
    }
}
