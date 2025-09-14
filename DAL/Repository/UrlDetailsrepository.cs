using Microsoft.EntityFrameworkCore;
using UrlShortener.DAL.Context;
using UrlShortener.DAL.Interfaces;
using UrlShortener.DAL.Models;

namespace UrlShortener.DAL.Repository
{
    public class UrlDetailsrepository : AbstractRepository, IUrlDetailsRepository
    {
        private readonly UrlDbContext dbContext;
        public UrlDetailsrepository(UrlDbContext context) : base(context)
        {
            this.dbContext = context;
        }

        public async Task AddEntityAsync(UrlDetails entity)
        {
            await this.dbContext.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<UrlDetails> GetByIdEntityAsync(int id)
        {
            var entity = await this.dbContext.UrlDetails.FirstOrDefaultAsync(x => x.UrlId == id);
            return entity!;
        }
    }
}
