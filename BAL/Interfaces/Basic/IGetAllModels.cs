namespace UrlShortener.BAL.Interfaces.Basic
{
    public interface IGetAllModels<TModel>
    {
        IEnumerable<TModel> GetAllModels();
    }
}
