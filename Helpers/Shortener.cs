using UrlShortener.Helpers.Interfaces;

namespace UrlShortener.Helpers
{
    public class Shortener : IShortener
    {
        public Uri GetShortUrl(Uri url)
        {
            return url;
        }
    }
}