using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Repositories;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;
using DataBaseLayout.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AirFlightsServer.Services;

public class UserService : IUserService
{
    private readonly SignInManager<User> _signinManager;
    private readonly UserManager<User> _userManager;

    public UserService(SignInManager<User> signinManager, UserManager<User> userManager)
    {
        _signinManager = signinManager;
        _userManager = userManager;
    }

    public async Task<bool> SignInAsync(string userName, string password, bool rememberMe)
    {
        var isLogged = await _signinManager.PasswordSignInAsync(userName, password, rememberMe, false);
        return isLogged.Succeeded;
    }

    public async Task SignOutAsync()
    {
        await _signinManager.SignOutAsync();
    }


    public async Task<IList<Models.User>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var response = users.Select(u => new Models.User()
        {
            CNP = u.CNP,
            Document = u.Document,
            Email = u.Email,
            FirstName = u.FirstName,
            LastName = u.LastName,
            PhoneNumber = u.PhoneNumber,
            ProfileImage = u.ProfileImage,
            ProfileImageFileName = u.ProfileImageFileName,
            Id = u.Id,
            ProfileImageName = u.ProfileImageName,
            UserName = u.UserName
        }).ToList();
        return response;
    }

    public async Task<Models.User> GetUserByCNPAsync(string CNP)
    {
        var user = await _userManager.Users.FirstAsync(s => s.Id == CNP && s.CNP == CNP);
        var response = new Models.User()
        {
            CNP = user.CNP,
            Document = user.Document,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            ProfileImage = user.ProfileImage,
            ProfileImageFileName = user.ProfileImageFileName,
            Id = user.Id,
            ProfileImageName = user.ProfileImageName,
            UserName = user.UserName
        };
        return response;
    }

    public async Task<IdentityResult> RegisterUserAsync(User model, string password)
    {

        var entity = new User()
        {
            Id = model.CNP,
            Document = model.Document,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            ProfileImage = model.ProfileImage,
            ProfileImageFileName = model.ProfileImageFileName,
            ProfileImageName = model.ProfileImageName,
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            UserName = model.UserName,
        };
        var result = await _userManager.CreateAsync(entity, password);

        return result;
    }

    public async Task UpdateUserAsync(User model)
    {
        var entity = new DataBaseLayout.Models.User()
        {
            CNP = model.CNP,
            Document = model.Document,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password,
            PhoneNumber = model.PhoneNumber,
            ProfileImage = model.ProfileImage
        };
        await _userRepository.UpdateUserAsync(entity);
    }

    public async Task DeleteUserAsync(string CNP)
    {
        await _userRepository.DeleteUserAsync(CNP);
    }
}