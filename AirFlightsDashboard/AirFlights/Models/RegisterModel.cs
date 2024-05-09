using System.ComponentModel.DataAnnotations;

namespace AirFlightsClient.Models;

public class RegisterModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}