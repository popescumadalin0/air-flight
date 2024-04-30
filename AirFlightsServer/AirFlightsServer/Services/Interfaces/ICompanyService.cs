using Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace AirFlightsServer.Services.Interfaces;

public interface ICompanyService
{
    Task<IList<Company>> GetCompaniesAsync();
    Task<Company> GetCompanyAsync(Guid id);
    Task AddCompanyAsync(Company model);
    Task UpdateCompanyAsync(Company model);
    Task DeleteCompanyAsync(Guid id);
}