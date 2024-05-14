namespace Models.Response;

public class UserLoginResponse
{
    public string TokenType { get; set; }
    public string AccessToken { get; set; }
    public string ExpiresIn { get; set; }
    public string RefreshToken { get; set; }
}