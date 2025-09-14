using UrlShortener.BAL.Models;
using UrlShortener.Helpers.Commands;

namespace UrlShortener.Helpers.Policies
{
    public class UrlAuthorizationPolicy : IAuthorizationPolicy
    {
        public void CheckCreate(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("Only authorized users can create URLs.");
        }

        public void CheckDelete(DeleteUrlCommand command, UrlModel url)
        {
            if (string.IsNullOrEmpty(command.UserId))
                throw new UnauthorizedAccessException();

            if (command.IsAdmin)
                return;

            if (url.UserId != command.UserId)
                throw new UnauthorizedAccessException("You can delete only your own URLs.");
        }
    }
}
