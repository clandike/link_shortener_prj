using UrlShortener.Exceptions;
using UrlShortener.Helpers.Interfaces;

namespace UrlShortener.Helpers
{
    public class UrlChecker : IUrlChecker
    {
        public Uri CheckAndReturnValidUrl(string? url)
        {
            UriCreationOptions options = new UriCreationOptions();
            Uri.TryCreate(url, in options, out Uri? result);

            if(result == null)
            {
                throw new InvalidUrlException();
            }

            return result!;
        }
    }
}
