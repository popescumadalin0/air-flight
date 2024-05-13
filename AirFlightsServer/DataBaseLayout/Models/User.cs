using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DataBaseLayout.Models;

public class User : IdentityUser
{
    public string CNP => Id;
    public byte[] ProfileImage { get; set; }
    public string ProfileImageName { get; set; }
    public string ProfileImageFileName { get; set; }

    public byte[] Document { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Booking> Reservations { get; set; }

}