using System.Collections.Generic;
using DataBaseLayout.Models;

namespace AirFlightsServer.SDK.RefitModels.ResponseModels;

public class UsersResponse
{
    public List<User> Users { get; set; }
}