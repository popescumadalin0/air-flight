using System.ComponentModel.DataAnnotations;

namespace AirFlightsClient.Models;

public class RegisterModel
{
    [Required]
    public string CNP { get; set; }

    [Required]

    public string Password { get; set; }
    [Required]

    public string ConfirmPassword { get; set; }

    [Required]

    public string PhoneNumber { get; set; }

    public byte[] ProfileImage { get; set; } 
    

    [Required]

    public string FirstName { get; set; }

    [Required]

    public string LastName { get; set; }

    [Required]

    public string Email { get; set; }
}