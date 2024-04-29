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


    [Get("/api/AirFlight")]
    Task<List<AirFlightTicket>> GetAirFlightsAsync();

    [Get("/api/AirFlight/{id}")]
    Task<AirFlightTicket> GetAirFlightAsync(Guid id);

    [Post("/api/AirFlight")]
    Task CreateAirFlightAsync(AirFlightTicket airFlight);

    [Put("/api/AirFlight")]
    Task UpdateAirFlightAsync(AirFlightTicket airFlight);

    [Delete("/api/AirFlight/{id}")]
    Task DeleteAirFlightAsync(Guid id);


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

}

