using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataBaseLayout.Models;
[PrimaryKey(nameof(CNP))]
public class User
{
    public string CNP { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public byte[] ProfileImage { get; set; }
    public byte[] Document { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [Required]
    public Role Role { get; set; }
    public ICollection<Booking> Reservations { get; set; }

}