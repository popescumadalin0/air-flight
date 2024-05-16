using System.ComponentModel.DataAnnotations;

namespace AirFlightsDashboard.Models;

public class AccountDetailsModel
{
    [Required]
    public string CNP { get; set; }

    [Required]

    public string PhoneNumber { get; set; }

    public string ProfileImage { get; set; }

    [Required]

    public string FirstName { get; set; }

    [Required]

    public string LastName { get; set; }

    [Required]

    public string Email { get; set; }

    [Required]

    public string UserName { get; set; }
}