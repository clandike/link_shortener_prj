using UrlShortener.DAL.Interfaces.Basic;
using UrlShortener.DAL.Models;

namespace UrlShortener.DAL.Interfaces
{
    public interface IUrlDetailsRepository : IGetByIdEntity<UrlDetails>, IAddEnitity<UrlDetails>
    {
    }
}
