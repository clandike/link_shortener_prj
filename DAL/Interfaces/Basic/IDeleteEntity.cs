namespace UrlShortener.DAL.Interfaces.Basic
{
    public interface IDelete<TEntity>
    {
        Task DeleteEntityAsync(TEntity entity);
    }
}
