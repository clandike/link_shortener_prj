using UrlShortener.BAL.Interfaces;
using UrlShortener.DAL.Interfaces;
using UrlShortener.DAL.Models;

namespace UrlShortener.BAL.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository repository;

        public UrlService(IUrlRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(Url entity)
        {
            await repository.AddEntityAsync(entity);
        }

        public async Task DeleteAsync(Url entity)
        {
            await repository.DeleteEntityAsync(entity);
        }

        public IEnumerable<Url> GetAllModels()
        {
            var enities = repository.GetAllEntities();
            return enities;
        }

        public async Task<Url> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdEntityAsync(id);
            return entity;
        }
    }
}
