namespace UrlShortener.DAL.Interfaces.Basic
{
    public interface IGetByIdEntity<TEntity>
    {
        Task<TEntity> GetByIdEntityAsync(int id);
    }
}
