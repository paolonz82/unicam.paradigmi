namespace Unicam.Paradigmi.Application.Options
{
    public class EmailOption
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string From { get; set; }
        public List<string> Tos { get; set; }

    }
}
