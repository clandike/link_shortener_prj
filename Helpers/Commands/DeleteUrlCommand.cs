namespace UrlShortener.Helpers.Commands
{
    public class DeleteUrlCommand
    {
        public int UrlId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }

    }
}
