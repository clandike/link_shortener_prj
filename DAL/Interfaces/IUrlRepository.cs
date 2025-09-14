using UrlShortener.DAL.Interfaces.Basic;
using UrlShortener.DAL.Models;

namespace UrlShortener.DAL.Interfaces
{
    public interface IUrlRepository : IAddEnitity<Url>, IGetByIdEntity<Url>, IGetAllEntity<Url>, IDelete<Url>
    {
    }
}
