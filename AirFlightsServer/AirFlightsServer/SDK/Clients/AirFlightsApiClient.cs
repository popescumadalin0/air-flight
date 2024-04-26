using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirFlightsServer.SDK.Interfaces;
using AirFlightsServer.SDK.RefitModels;
using DataBaseLayout.Models;


namespace AirFlightsServer.SDK.Clients;

/// <summary>
/// Here we add the endpoints for the entire application
/// </summary>
public class AirFlightsApiClient : RefitApiClient<IAirFlightsApi>, IAirFlightsApiClient
{
    private readonly IAirFlightsApi _apiClient;

    private readonly ILogger<AirFlightsApiClient> _logger;

    public AirFlightsApiClient(IAirFlightsApi apiClient, ILogger<AirFlightsApiClient> logger) : base()
    {
        _apiClient = apiClient;
        _logger = logger;
    }

    public async Task<ApiResponseMessage<List<User>>> GetUsersAsync()
    {
        try
        {
            var task = _apiClient.GetUsersAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetUsersAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<User>> GetUserAsync(string CNP)
    {
        try
        {
            var task = _apiClient.GetUserAsync(CNP);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetUserAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteUserAsync(string CNP)
    {
        try
        {
            var task = _apiClient.DeleteUserAsync(CNP);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteUserAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateUserAsync(User user)
    {
        try
        {
            var task = _apiClient.CreateUserAsync(user);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateUserAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateUserAsync(User user)
    {
        try
        {
            var task = _apiClient.UpdateUserAsync(user);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateUserAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<AirFlight>>> GetAirFlightsAsync()
    {
        try
        {
            var task = _apiClient.GetAirFlightsAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAirFlightsAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<AirFlight>> GetAirFlightAsync(Guid id)
    {
        try
        {
            var task = _apiClient.GetAirFlightAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAirFlightAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateAirFlightAsync(AirFlight airFlight)
    {
        try
        {
            var task = _apiClient.CreateAirFlightAsync(airFlight);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateAirFlightAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateAirFlightAsync(AirFlight airFlight)
    {
        try
        {
            var task = _apiClient.UpdateAirFlightAsync(airFlight);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateAirFlightAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteAirFlightAsync(Guid id)
    {
        try
        {
            var task = _apiClient.DeleteAirFlightAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteAirFlightAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<Company>>> GetCompaniesAsync()
    {
        try
        {
            var task = _apiClient.GetCompaniesAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetCompaniesAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<Company>> GetCompanyAsync(Guid id)
    {
        try
        {
            var task = _apiClient.GetCompanyAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetCompanyAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateCompanyAsync(Company company)
    {
        try
        {
            var task = _apiClient.CreateCompanyAsync(company);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateCompanyAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateCompanyAsync(Company company)
    {
        try
        {
            var task = _apiClient.UpdateCompanyAsync(company);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateCompanyAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteCompanyAsync(Guid id)
    {
        try
        {
            var task = _apiClient.DeleteCompanyAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteCompanyAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<Layover>>> GetLayoversAsync()
    {
        try
        {
            var task = _apiClient.GetLayoversAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetLayoversAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<Layover>> GetLayoverAsync(Guid id)
    {
        try
        {
            var task = _apiClient.GetLayoverAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetLayoverAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateLayoverAsync(Layover layover)
    {
        try
        {
            var task = _apiClient.CreateLayoverAsync(layover);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateLayoverAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateLayoverAsync(Layover layover)
    {
        try
        {
            var task = _apiClient.UpdateLayoverAsync(layover);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateLayoverAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteLayoverAsync(Guid id)
    {
        try
        {
            var task = _apiClient.DeleteLayoverAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteLayoverAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<PlaneFacility>>> GetPlaneFacilitiesAsync()
    {
        try
        {
            var task = _apiClient.GetPlaneFacilitiesAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetPlaneFacilitiesAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<PlaneFacility>> GetPlaneFacilityAsync(Guid id)
    {
        try
        {
            var task = _apiClient.GetPlaneFacilityAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetPlaneFacilityAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreatePlaneFacilityAsync(PlaneFacility planeFacility)
    {
        try
        {
            var task = _apiClient.CreatePlaneFacilityAsync(planeFacility);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreatePlaneFacilityAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdatePlaneFacilityAsync(PlaneFacility planeFacility)
    {
        try
        {
            var task = _apiClient.UpdatePlaneFacilityAsync(planeFacility);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdatePlaneFacilityAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeletePlaneFacilityAsync(Guid id)
    {
        try
        {
            var task = _apiClient.DeletePlaneFacilityAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeletePlaneFacilityAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<PlaneSeat>>> GetPlaneSeatsAsync()
    {
        try
        {
            var task = _apiClient.GetPlaneSeatsAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetPlaneSeatsAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<PlaneSeat>> GetPlaneSeatAsync(Guid id)
    {
        try
        {
            var task = _apiClient.GetPlaneSeatAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetPlaneFacilityAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreatePlaneSeatAsync(PlaneSeat planeSeat)
    {
        try
        {
            var task = _apiClient.CreatePlaneSeatAsync(planeSeat);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreatePlaneSeatAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdatePlaneSeatAsync(PlaneSeat planeSeat)
    {

        try
        {
            var task = _apiClient.UpdatePlaneSeatAsync(planeSeat);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdatePlaneSeatAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeletePlaneSeatAsync(Guid id)
    {
        try
        {
            var task = _apiClient.DeletePlaneSeatAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeletePlaneSeatAsync)}");
            throw;
        }
    }
}