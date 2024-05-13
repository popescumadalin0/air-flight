using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace AirFlightsServer.Services.Interfaces;

public interface ITicketService
{
    /// <summary/>
    Task<IList<Ticket>> GetTicketsAsync();

    /// <summary/>
    Task<Ticket> GetTicketAsync(Guid id);

    /// <summary/>
    Task CreateTicketAsync(Ticket ticket);

    /// <summary/>
    Task UpdateTicketAsync(Ticket  ticket);

    /// <summary/>
    Task DeleteTicketAsync(Guid id);
}