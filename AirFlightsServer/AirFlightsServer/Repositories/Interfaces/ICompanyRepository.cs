
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface ICompanyRepository
{
    Task<List<Company>> GetCompaniesAsync();
    Task AddCompanyAsync(Company model);
    Task DeleteCompanyAsync(Guid  id);
}