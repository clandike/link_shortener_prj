namespace UrlShortener.Helpers.Interfaces
{
    public interface IShortener
    {
        public Uri GetShortUrl(Uri url);
    }
}
