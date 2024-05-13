using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Refit;

namespace SDK.Interfaces;

/// <summary>
/// Here we add the endpoints for the entire application
/// </summary>
public interface IAirFlightsApi
{
    [Get("/api/User")]
    Task<List<User>> GetUsersAsync();

    [Get("/api/User/{CNP}")]
    Task<User> GetUserAsync(string CNP);

    [Delete("/api/User/{CNP}")]
    Task DeleteUserAsync(string CNP);

    [Post("/api/User")]
    Task CreateUserAsync(User user);

    [Put("/api/User")]
    Task UpdateUserAsync(User user);

    [Get("/api/Ticket")]
    Task<List<Ticket>> GetTicketsAsync();

    [Get("/api/Ticket/{id}")]
    Task<Ticket> GetTicketAsync(Guid id);

    [Post("/api/Ticket")]
    Task CreateTicketAsync(Ticket ticket);

    [Put("/api/Ticket")]
    Task UpdateTicketAsync(Ticket ticket);

    [Delete("/api/Ticket/{id}")]
    Task DeleteTicketAsync(Guid id);

    [Get("/api/Company")]
    Task<List<Company>> GetCompaniesAsync();

    [Get("/api/Company/{id}")]
    Task<Company> GetCompanyAsync(Guid id);

    [Post("/api/Company")]
    Task CreateCompanyAsync(Company company);

    [Put("/api/Company")]
    Task UpdateCompanyAsync(Company company);

    [Delete("/api/Company/{id}")]
    Task DeleteCompanyAsync(Guid id);

    [Get("/api/Layover")]
    Task<List<Layover>> GetLayoversAsync();

    [Get("/api/Layover/{id}")]
    Task<Layover> GetLayoverAsync(Guid id);

    [Post("/api/Layover")]
    Task CreateLayoverAsync(Layover layover);

    [Put("/api/Layover")]
    Task UpdateLayoverAsync(Layover layover);

    [Delete("/api/Layover/{id}")]
    Task DeleteLayoverAsync(Guid id);

    [Get("/api/PlaneFacility")]
    Task<List<PlaneFacility>> GetPlaneFacilitiesAsync();

    [Get("/api/PlaneFacility/{id}")]
    Task<PlaneFacility> GetPlaneFacilityAsync(Guid id);

    [Post("/api/PlaneFacility")]
    Task CreatePlaneFacilityAsync(PlaneFacility planeFacility);

    [Put("/api/PlaneFacility")]
    Task UpdatePlaneFacilityAsync(PlaneFacility planeFacility);

    [Delete("/api/PlaneFacility/{id}")]
    Task DeletePlaneFacilityAsync(Guid id);

    [Get("/api/PlaneSeat")]
    Task<List<PlaneSeat>> GetPlaneSeatsAsync();

    [Get("/api/PlaneSeat/{id}")]
    Task<PlaneSeat> GetPlaneSeatAsync(Guid id);

    [Post("/api/PlaneSeat")]
    Task CreatePlaneSeatAsync(PlaneSeat planeSeat);

    [Put("/api/PlaneSeat")]
    Task UpdatePlaneSeatAsync(PlaneSeat planeSeat);

    [Delete("/api/PlaneSeat/{id}")]
    Task DeletePlaneSeatAsync(Guid id);

    [Get("/api/Role")]
    Task<List<Role>> GetRolesAsync();

    [Get("/api/Role/{name}")]
    Task<Role> GetRoleAsync(string name);

    [Post("/api/Role")]
    Task CreateRoleAsync(Role role);

    [Put("/api/Role")]
    Task UpdateRoleAsync(Role role);

    [Delete("/api/Role/{name}")]
    Task DeleteRoleAsync(string name);

    [Get("/api/Booking")]
    Task<List<Booking>> GetBookingsAsync();

    [Get("/api/Booking/{id}")]
    Task<Booking> GetBookingAsync(Guid id);

    [Post("/api/Booking")]
    Task CreateBookingAsync(Booking booking);

    [Put("/api/Booking")]
    Task UpdateBookingAsync(Booking booking);

    [Delete("/api/Booking/{id}")]
    Task DeleteBookingAsync(Guid id);
}

