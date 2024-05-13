using AirFlightsServer.ResponseModels;
using AirFlightsServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Models;

namespace AirFlightsServer.Controllers;

public class UserController:BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        try
        {
            var result = await _userService.GetUsersAsync();
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<User>>(result.ToList()));

        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<User>>(ex));
        }
    }

    [HttpGet("{CNP}")]
    public async Task<IActionResult> GetUserAsync(string CNP)
    {
        try
        {
            var result = await _userService.GetUserByCNPAsync(CNP);

            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<User>(result));

        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<User>(ex));
        }
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUserAsync(User user)
    {
        try
        {
            user.ProfileImage = new byte[7];
            user.Document = new byte[7];
            var result = await _userService.RegisterUserAsync(user, "Admin1234!");

            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<IdentityResult>(result));

        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync(User user)
    {
        try
        {
            await _userService.UpdateUserAsync(user);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }

    [HttpDelete("{CNP}")]
    public async Task<IActionResult> DeleteUserAsync(string CNP)
    {
        try
        {
            await _userService.DeleteUserAsync(CNP);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse());
        }
        catch (Exception ex)
        {
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse(ex));
        }
    }
}