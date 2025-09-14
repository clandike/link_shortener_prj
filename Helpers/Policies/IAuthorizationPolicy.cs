using UrlShortener.BAL.Models;
using UrlShortener.Helpers.Commands;

namespace UrlShortener.Helpers.Policies
{
    public interface IAuthorizationPolicy
    {
        void CheckCreate(string userId);
        void CheckDelete(DeleteUrlCommand command, UrlModel url);
    }
}
