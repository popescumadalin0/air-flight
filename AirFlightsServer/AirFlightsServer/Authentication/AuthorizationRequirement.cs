using Microsoft.AspNetCore.Authorization;

namespace AirFlightsServer.Authentication
{
    public class AuthorizationRequirement : IAuthorizationRequirement
    {
        public string RoleName { get; }

        public AuthorizationRequirement(string roleName)
        {
            RoleName = roleName;
        }
    }
}
