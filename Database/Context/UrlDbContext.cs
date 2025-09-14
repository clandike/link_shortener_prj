using Microsoft.EntityFrameworkCore;
using UrlShortener.DAL.DbUrlModels;

namespace UrlShortener.Database.Context
{
    public class UrlDbContext : DbContext
    {
        public UrlDbContext(DbContextOptions<UrlDbContext> options)
            : base(options)
        {
        }

        public DbSet<Url> Urls => Set<Url>();
    }
}
