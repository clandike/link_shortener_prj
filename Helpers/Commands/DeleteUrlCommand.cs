namespace UrlShortener.Helpers.Commands
{
    public class DeleteUrlCommand
    {
        public int UrlId { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
