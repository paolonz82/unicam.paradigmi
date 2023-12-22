namespace Unicam.Paradigmi.Application.Options
{
    public class EmailOption
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Tos { get; set; }
    }
}
