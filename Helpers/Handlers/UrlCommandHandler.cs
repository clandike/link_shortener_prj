using UrlShortener.BAL.Interfaces;
using UrlShortener.BAL.Models;
using UrlShortener.Helpers.Commands;
using UrlShortener.Helpers.Policies;

namespace UrlShortener.Helpers.Handlers
{
    public class UrlCommandHandler
    {
        private readonly IUrlService urlService;
        private readonly IAuthorizationPolicy policy;
        private readonly IUrlDetailsService urlDetailsService;

        public UrlCommandHandler(IUrlService urlService, IAuthorizationPolicy policy, IUrlDetailsService urlDetailsService)
        {
            this.urlService = urlService;
            this.policy = policy;
            this.urlDetailsService = urlDetailsService;
        }

        public async Task Handle(CreateUrlCommand command)
        {
            policy.CheckCreate(command.UserId);

            var model = new UrlModel
            {
                OriginalUrl = command.OriginalUrl,
                ShortedUrl = command.ShortedUrl,
                UserId = command.UserId
            };

            await urlService.CreateAsync(model);

            var entity = urlService.GetAllModels().FirstOrDefault(x => x.OriginalUrl == model.OriginalUrl && x.ShortedUrl == model.ShortedUrl);

            var urlDetailsModel = new UrlDetailsModel()
            {
                UrlId = entity!.Id,
                CreatedBy = command.UserName,
            };

            await urlDetailsService.CreateAsync(urlDetailsModel);
        }

        public async Task Handle(DeleteUrlCommand command)
        {
            var url = await urlService.GetByIdAsync(command.UrlId);
            var urlDetails = await urlDetailsService.GetByIdAsync(command.UrlId);
            url.UserId = urlDetails.CreatedBy;

            policy.CheckDelete(command, url);

            await urlService.DeleteByIdAsync(command.UrlId);
        }

        public IEnumerable<UrlModel> Handle()
        {
            return urlService.GetAllModels();
        }
    }
}
