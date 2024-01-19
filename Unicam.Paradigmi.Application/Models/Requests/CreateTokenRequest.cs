namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class CreateTokenRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;   
    }
}
