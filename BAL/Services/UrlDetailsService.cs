using UrlShortener.BAL.Interfaces;
using UrlShortener.DAL.Interfaces;
using UrlShortener.DAL.Models;

namespace UrlShortener.BAL.Services
{
    public class UrlDetailsService : IUrlDetailsService
    {
        private readonly IUrlDetailsRepository urlDetailsRepository;

        public UrlDetailsService(IUrlDetailsRepository urlRepositiory)
        {
            this.urlDetailsRepository = urlRepositiory;
        }
        public async Task CreateAsync(UrlDetails model)
        {
            await urlDetailsRepository.AddEntityAsync(model);
        }

        public async Task<UrlDetails> GetByIdAsync(int id)
        {
            var model = await urlDetailsRepository.GetByIdEntityAsync(id);
            return model;
        }
    }
}
