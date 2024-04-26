namespace AirFlightsServer.Models
{
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
    }
}
