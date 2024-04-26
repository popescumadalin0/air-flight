<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/CompanyRepository.cs
﻿using AirFlightsServer.Repositories.Interfaces;
=======
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Server.Repositories.Interfaces;
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/CompanyRepository.cs
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;

<<<<<<< Updated upstream:AirFlightsServer/AirFlightsServer/Repositories/CompanyRepository.cs
namespace AirFlightsServer.Repositories
=======
namespace AirFlightsServer.Server.Repositories;

public class CompanyRepository : ICompanyRepository
>>>>>>> Stashed changes:AirFlightsServer/AirFlightsServer/Server/Repositories/CompanyRepository.cs
{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly IContext _context;

        public CompanyRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            var company = await _context.Companies.ToListAsync();
            return company;

        }

        public async Task AddCompanyAsync(Company model)
        {
            await _context.Companies.AddAsync(model);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompanyAsync(Guid id)
        {
            var company = await _context.Companies.SingleAsync(scp => scp.Id == id);
            _context.Companies.Remove(company);

            await _context.SaveChangesAsync();
        }
    }
}
