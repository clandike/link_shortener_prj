using Microsoft.EntityFrameworkCore;
using UrlShortener.DAL.Models;
using UrlShortener.DAL.Interfaces;

namespace UrlShortener.DAL.Repository
{
    public class UrlRepository : AbstractRepository, IUrlRepositiory
    {
        private readonly DbSet<Url> dbSet;

        public UrlRepository(DbContext context) : base(context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.dbSet = context.Set<Url>();
        }

        public void Add(Url entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Url entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Url> GetAll()
        {
            var values = this.dbSet.Select(x => x).ToList();
            return values;
        }


        public Url GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
