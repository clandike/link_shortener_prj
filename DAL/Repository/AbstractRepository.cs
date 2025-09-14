using Microsoft.EntityFrameworkCore;

namespace UrlShortener.DAL.Repository
{
    public abstract class AbstractRepository
    {
        protected readonly DbContext context;

        protected AbstractRepository(DbContext context)
        {
            this.context = context;
        }
    }
}
