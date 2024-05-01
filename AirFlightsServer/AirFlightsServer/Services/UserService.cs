using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer.Repositories;
using AirFlightsServer.Repositories.Interfaces;
using AirFlightsServer.Services.Interfaces;
using Models;

namespace AirFlightsServer.Services;

public class UserService:IUserService
{ 
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IList<User>> GetUsersAsync()
    {
        var user = await _userRepository.GetUsersAsync();
        var response = user.Select(u => new User()
        {
            CNP = u.CNP,
            Document = u.Document,
            Email = u.Email,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Password = u.Password,
            PhoneNumber = u.PhoneNumber,
            ProfileImage = u.ProfileImage
        }).ToList();
        return response;
    }

    public async Task<User> GetUserAsync(string CNP)
    {
        var user = await _userRepository.GetUserAsync(CNP);
        var response = new User()
        {
            CNP = user.CNP,
            Document = user.Document,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            ProfileImage = user.ProfileImage
        };
        return response;
    }

    public async Task AddUserAsync(User model)
    {

        var entity = new DataBaseLayout.Models.User()
        {
            CNP = model.CNP,
            Document = model.Document,
            Email =model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Password = model.Password,
            PhoneNumber = model.PhoneNumber,
            ProfileImage = model.ProfileImage
        };
        await _userRepository.AddUserAsync(entity);
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