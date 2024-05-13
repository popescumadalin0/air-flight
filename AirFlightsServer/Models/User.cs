namespace Models;

public class User
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string CNP { get; set; }
    public string PhoneNumber { get; set; }
    public byte[] ProfileImage { get; set; }
    public string ProfileImageName { get; set; }
    public string ProfileImageFileName { get; set; }

    public byte[] Document { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}