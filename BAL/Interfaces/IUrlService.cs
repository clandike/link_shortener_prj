using UrlShortener.BAL.Interfaces.Basic;
using UrlShortener.DAL.Models;

namespace UrlShortener.BAL.Interfaces
{
    public interface IUrlService : ICreateModel<Url>, IDeleteModel<Url>, IGetAllModels<Url>, IGetByIdModel<Url>
    {
    }
}
