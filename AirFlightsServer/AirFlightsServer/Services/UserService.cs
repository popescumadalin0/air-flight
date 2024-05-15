using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AirFlightsServer.Services.Interfaces;
using DataBaseLayout.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Constants;

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

    /// <inheritdoc />
    public async Task SignOutAsync()
    {
        await _signinManager.SignOutAsync();
    }


    /// <inheritdoc />
    public async Task<IList<Models.User>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var response = users.Select(ModelToDto).ToList();
        return response;
    }

    /// <inheritdoc />
    public async Task<Models.User> GetUserByCNPAsync(string CNP)
    {
        var user = await _userManager.Users.FirstAsync(s => s.Id == CNP && s.CNP == CNP);

        return ModelToDto(user);
    }

    public async Task<Models.User> GetUserByUserNameAsync(string userName)
    {
        var user = await _userManager.Users.FirstAsync(s => s.UserName == userName);

        return ModelToDto(user);
    }

    /// <inheritdoc />
    public async Task<IdentityResult> RegisterUserAsync(Models.User model, string password)
    {
        var user = DtoToModel(model);

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return result;
        }

        result = await _userManager.AddToRoleAsync(user, Roles.User);

        return result;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> UpdateUserAsync(Models.User user)
    {
        var userModel = await _userManager.Users.FirstAsync(s => s.Id == user.CNP && s.CNP == user.CNP);

        userModel.FirstName = user.FirstName;
        userModel.LastName = user.LastName;
        userModel.ProfileImage = user.ProfileImage;
        userModel.ProfileImageName = user.ProfileImageName;
        userModel.ProfileImageFileName = user.ProfileImageFileName;
        userModel.Document = user.Document;

        var result = await _userManager.UpdateAsync(userModel);

        return result;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> UpdateUserEmailAsync(Models.User user, string newEmail, string token)
    {
        var userModel = await _userManager.Users.FirstAsync(s => s.Id == user.CNP && s.CNP == user.CNP);
        var result = await _userManager.ChangeEmailAsync(userModel, newEmail, token);
        return result;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> UpdateUserPasswordAsync(Models.User user, string oldPassword, string newPassword)
    {
        var result = await _userManager.ChangePasswordAsync(DtoToModel(user), oldPassword, newPassword);
        return result;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> UpdateUserPhoneNumberAsync(Models.User user, string newPhoneNumber, string token)
    {
        var userModel = await _userManager.Users.FirstAsync(s => s.Id == user.CNP && s.CNP == user.CNP);
        var result = await _userManager.ChangePhoneNumberAsync(userModel, newPhoneNumber, token);
        return result;
    }

    /// <inheritdoc />
    public async Task<IdentityResult> DeleteUserAsync(string CNP)
    {
        var user = await _userManager.Users.FirstAsync(s => s.Id == CNP && s.CNP == CNP);

        return await _userManager.DeleteAsync(user);
    }

    private static User DtoToModel(Models.User model)
    {
        var entity = new User
        {
            Id = model.CNP,
            CNP = model.CNP,
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

        return entity;
    }

    private static Models.User ModelToDto(User model)
    {
        var dto = new Models.User
        {
            CNP = model.CNP,
            Document = model.Document,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            ProfileImage = model.ProfileImage,
            ProfileImageFileName = model.ProfileImageFileName,
            Id = model.Id,
            ProfileImageName = model.ProfileImageName,
            UserName = model.UserName,
        };

        return dto;
    }
}