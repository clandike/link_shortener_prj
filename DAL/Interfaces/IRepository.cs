namespace UrlShortener.DAL.Interfaces
{

    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void DeleteById(int id);

        void Update(TEntity entity);
    }
}
