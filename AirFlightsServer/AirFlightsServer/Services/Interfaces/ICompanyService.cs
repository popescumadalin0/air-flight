using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;


namespace AirFlightsServer.Repositories.Interfaces;

public interface ICompanyRepository
{
    Task<IList<Company>> GetCompaniesAsync();
    Task<Company> GetCompanyAsync(Guid id);
    Task AddCompanyAsync(Company model);
    Task UpdateCompanyAsync(Company model);
    Task DeleteCompanyAsync(Guid id);
}