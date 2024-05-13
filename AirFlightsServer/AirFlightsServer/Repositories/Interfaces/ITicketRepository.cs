using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLayout.Models;

namespace AirFlightsServer.Repositories.Interfaces;

public interface ITicketRepository
{
    /// <summary/>
    Task<IList<Ticket>> GetTicketsAsync();

    /// <summary/>
    Task<Ticket> GetTicketAsync(Guid id);

    /// <summary/>
    Task AddTicketAsync(Ticket model);

    /// <summary/>
    Task UpdateTicketAsync(Ticket  ticket);

    /// <summary/>
    Task DeleteTicketAsync(Guid id);
}