namespace UrlShortener.Helpers.Commands
{
    public class CreateUrlCommand
    {
        public string OriginalUrl { get; set; }

        public string ShortedUrl { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
