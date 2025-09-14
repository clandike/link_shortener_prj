namespace UrlShortener.BAL.Interfaces.Basic
{
    public interface IDeleteModel<TModel>
    {
        Task DeleteAsync(TModel model);
    }
}
