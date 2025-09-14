using UrlShortener.DAL.Models;
using UrlShortener.DAL.Interfaces;
using UrlShortener.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.DAL.Repository
{
    public class UrlRepository : AbstractRepository, IUrlRepository
    {
        private readonly UrlDbContext dbContext;

        public UrlRepository(UrlDbContext context) : base(context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.dbContext = context;
        }

        public async Task AddEntityAsync(Url entity)
        {
            await this.dbContext.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(Url entity)
        {
            this.dbContext.Remove(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<Url> GetAllEntities()
        {
            var entities = this.dbContext.Urls.Select(x => x);
            return entities;
        }

        public async Task<Url> GetByIdEntityAsync(int id)
        {
            var entity = await this.dbContext.Urls.FirstOrDefaultAsync(x => x.Id == id);
            return entity!;
        }
    }
}
