using UrlShortener.BAL.Interfaces.Basic;
using UrlShortener.DAL.Models;

namespace UrlShortener.BAL.Interfaces
{
    public interface IUrlDetailsService : ICreateModel<UrlDetails>, IGetByIdModel<UrlDetails>
    {
    }
}
