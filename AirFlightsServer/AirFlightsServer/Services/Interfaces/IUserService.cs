using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.Request;

namespace AirFlightsServer.Services.Interfaces;

public interface IUserService
{
    /// <summary/>
    Task<bool> SignInAsync(string userName, string password, bool rememberMe);

    /// <summary/>
    Task SignOutAsync();

    /// <summary/>
    Task<IList<User>> GetUsersAsync();

    /// <summary/>
    Task<User> GetUserByCNPAsync(string CNP);

    /// <summary/>
    Task<User> GetUserByUserNameAsync(string userName);

    /// <summary/>
    Task<IdentityResult> RegisterUserAsync(User model, string password);

    /// <summary/>
   // Task<IdentityResult> LoginUserAsync(string username, string password);

    /// <summary/>
    Task<IdentityResult> UpdateUserAsync(User user);

    /// <summary/>
    Task<IdentityResult> UpdateUserEmailAsync(User user, string newEmail, string token);

    /// <summary/>
    Task<IdentityResult> UpdateUserPasswordAsync(User user, string oldPassword, string newPassword);

    /// <summary/>
    Task<IdentityResult> UpdateUserPhoneNumberAsync(User user, string newPhoneNumber, string token);

    /// <summary/>
    Task<IdentityResult> DeleteUserAsync(string CNP);
}