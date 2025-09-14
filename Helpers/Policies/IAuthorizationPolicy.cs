using UrlShortener.BAL.Interfaces;
using UrlShortener.BAL.Models;
using UrlShortener.Helpers.Commands;

namespace UrlShortener.Helpers.Policies
{
    public interface IAuthorizationPolicy
    {
        void CheckCreate(CreateUrlCommand command, IUrlService service);
        void CheckDelete(DeleteUrlCommand command, UrlModel url);
    }
}
