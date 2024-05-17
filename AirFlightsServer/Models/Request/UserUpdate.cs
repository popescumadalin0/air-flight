namespace Models;

public class UserUpdate
{
    public string CNP { get; set; }
    public string PhoneNumber { get; set; }
    public string ProfileImage { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}