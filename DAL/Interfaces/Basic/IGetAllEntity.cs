namespace UrlShortener.DAL.Interfaces.Basic
{
    public interface IGetAllEntity<TEntity>
    {
        IEnumerable<TEntity> GetAllEntities();
    }
}
