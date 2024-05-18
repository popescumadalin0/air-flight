using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;

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
        var tickets = await _ticketRepository.GetTicketsAsync();

        var response = tickets.Select(t =>
        {
            var startLayover = t.Layovers.MaxBy(l => l.Order);
            var endLayover = t.Layovers.MinBy(l => l.Order);

            var response = new Models.Ticket
            {
                Currency = t.Currency,
                Id = t.Id,
                Price = t.Price,
                ArrivalTime = startLayover.ArrivalDuration,
                DepartureTime = endLayover.DepartureTime,
                FromCountry = startLayover.StartPointCountry,
                FromCity = startLayover.StartPointCity,
                NumberOfSeats = t.Layovers.Min(l => l.PlaneSeats.Count),
                ToCity = endLayover.DestinationCity,
                ToCountry = endLayover.DestinationCountry,
                Image = Convert.ToBase64String(t.Image)
            };

            return response;
        }).ToList();

        return response;
    }

    /// <inheritdoc />
    public async Task<Models.Ticket> GetTicketAsync(Guid id)
    {
        var ticket = await _ticketRepository.GetTicketAsync(id);

        var startLayover = ticket.Layovers.MaxBy(l => l.Order);
        var endLayover = ticket.Layovers.MinBy(l => l.Order);

        var response = new Models.Ticket
        {
            Currency = ticket.Currency,
            Id = ticket.Id,
            Price = ticket.Price,
            ArrivalTime = startLayover.ArrivalDuration,
            DepartureTime = endLayover.DepartureTime,
            FromCountry = startLayover.StartPointCountry,
            FromCity = startLayover.StartPointCity,
            NumberOfSeats = ticket.Layovers.Min(l => l.PlaneSeats.Count),
            ToCity = endLayover.DestinationCity,
            ToCountry = endLayover.DestinationCountry,
            Image = Convert.ToBase64String(ticket.Image)
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
            Image = Convert.FromBase64String(ticket.Image),
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