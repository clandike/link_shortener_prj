using Microsoft.EntityFrameworkCore;
using UrlShortener.DAL.Models;

namespace UrlShortener.DAL.Context
{
    public class UrlDbContext : DbContext
    {
        public UrlDbContext(DbContextOptions<UrlDbContext> options)
            : base(options)
        {
        }

        public DbSet<Url> Urls => Set<Url>();
        public DbSet<UrlDetails> UrlDetails => Set<UrlDetails>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UrlDetails>()
                .HasOne(u => u.Url)
                .WithMany(d => d.Details)
                .HasForeignKey(d => d.UrlId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
