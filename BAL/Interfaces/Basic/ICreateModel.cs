namespace UrlShortener.BAL.Interfaces.Basic
{
    public interface ICreateModel<TModel>
    {
        Task CreateAsync(TModel model);
    }
}
