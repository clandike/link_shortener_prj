namespace UrlShortener.Helpers.Interfaces
{
    public interface IUrlChecker
    {
        public Uri CheckAndReturnValidUrl(string? url);
    }
}
