using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;


namespace AirFlightsServer.Repositories.Interfaces;

public interface ICompanyRepository
{
    /// <summary/>
    Task<IList<Company>> GetCompaniesAsync();

    /// <summary/>
    Task<Company> GetCompanyAsync(Guid id);

    /// <summary/>
    Task AddCompanyAsync(Company model);

    /// <summary/>
    Task UpdateCompanyAsync(Company model);

    /// <summary/>
    Task DeleteCompanyAsync(Guid id);
}