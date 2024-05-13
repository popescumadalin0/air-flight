using System.Threading.Tasks;
using AirFlightsServer.ResponseModels;

namespace AirFlightsServer.Services.Interfaces;

public interface IEmailService
{
    /// <summary>
    /// Send an email.
    /// </summary>
    /// <param name="emailMessage">Message object to be sent</param>
    Task Send(EmailMessageModel emailMessage);
}