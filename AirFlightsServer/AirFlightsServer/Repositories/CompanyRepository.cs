using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;
using DataBaseLayout.Context;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;


namespace AirFlightsServer.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly IContext _context;

    public CompanyRepository(IContext context)
    {
        _context = context;
    }

    public async Task<IList<Company>> GetCompaniesAsync()
    {
        var company = await _context.Companies.ToListAsync();
        return company;

    }

    public async Task<Company> GetCompanyAsync(Guid id)
    {
        var company = await _context.Companies.FindAsync(id);

        return company;
    }

    public async Task AddCompanyAsync(Company model)
    {
        await _context.Companies.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCompanyAsync(Company model)
    {
        await _context.Companies.FindAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCompanyAsync(Guid id)
    {
        var company = await _context.Companies.SingleAsync(scp => scp.Id == id);
        _context.Companies.Remove(company);

        await _context.SaveChangesAsync();
    }
}
