using UrlShortener.BAL.Interfaces;
using UrlShortener.BAL.Models;
using UrlShortener.Helpers.Commands;

namespace UrlShortener.Helpers.Policies
{
    public class UrlAuthorizationPolicy : IAuthorizationPolicy
    {
        public void CheckCreate(CreateUrlCommand command, IUrlService service)
        {
            if (string.IsNullOrEmpty(command.UserId))
                throw new UnauthorizedAccessException("Тільки авторизовані користувачі можуть створювати URL адреси.");

            var entity = service.GetAllModels().SingleOrDefault(x => x.OriginalUrl == command.OriginalUrl);

            if (entity != null)
            {
                throw new InvalidOperationException();
            }
        }

        public void CheckDelete(DeleteUrlCommand command, UrlModel url)
        {
            if (string.IsNullOrEmpty(command.UserName))
                throw new UnauthorizedAccessException();

            if (command.IsAdmin)
                return;

            if (url.UserId != command.UserName)
                throw new UnauthorizedAccessException("Ви можете видаляти лише свої створені скорочені URL адреси.");
        }
    }
}
