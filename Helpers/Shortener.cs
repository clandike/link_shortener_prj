using UrlShortener.Helpers.Interfaces;

namespace UrlShortener.Helpers
{
    public class Shortener : IShortener
    {
        public Uri GetShortUrl(Uri url)
        {
            Uri result = new("https://google.com");
            return result;
        }
    }
}