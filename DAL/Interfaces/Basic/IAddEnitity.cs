namespace UrlShortener.DAL.Interfaces.Basic
{
    public interface IAddEnitity<in TEntity>
    {
        Task AddEntityAsync(TEntity entity);
    }
}
