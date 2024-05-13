using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;
using DataBaseLayout.Models;
using Models;

namespace AirFlightsServer.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }
    /// <inheritdoc />
    public async Task<IList<Models.Ticket>> GetTicketsAsync()
    {
        var airFlight = await _ticketRepository.GetTicketsAsync();

        var response = airFlight.Select(af => new Models.Ticket
        {
            Currency = af.Currency,
            Id = af.Id,
            Price = af.Price
        }).ToList();

        return response;

    }

    /// <inheritdoc />
    public async Task<Models.Ticket> GetTicketAsync(Guid id)
    {
        var airFlight = await _ticketRepository.GetTicketAsync(id);

        var response = new Models.Ticket
        {
            Currency = airFlight.Currency,
            Id = airFlight.Id,
            Price = airFlight.Price
        };

        return response;
    }

    /// <inheritdoc />
    public async Task CreateTicketAsync(Models.Ticket ticket)
    {
        var entity = new DataBaseLayout.Models.Ticket
        {
            Currency = ticket.Currency,
            Id = ticket.Id,
            Price = ticket.Price,
            //todo: sa vedem daca le adaugam de aici
            //Layovers = 
        };
        await _ticketRepository.AddTicketAsync(entity);
    }

    /// <inheritdoc />
    public async Task UpdateTicketAsync(Models.Ticket ticket)
    {
        var entity = new DataBaseLayout.Models.Ticket
        {
            Currency = ticket.Currency,
            Id = ticket.Id,
            Price = ticket.Price,
            //todo: sa vedem daca le adaugam de aici
            //Layovers = 
        };
        await _ticketRepository.UpdateTicketAsync(entity);
    }

    /// <inheritdoc />
    public async Task DeleteTicketAsync(Guid id)
    {
        await _ticketRepository.DeleteTicketAsync(id);
    }

}