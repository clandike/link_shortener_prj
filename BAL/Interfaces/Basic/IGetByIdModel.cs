namespace UrlShortener.BAL.Interfaces.Basic
{
    public interface IGetByIdModel<TModel>
    {
        Task<TModel> GetByIdAsync(int id);
    }
}
