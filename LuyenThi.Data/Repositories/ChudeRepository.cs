using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IChudeRepository : IRepository<Chude>
    {
    }

    public class ChudeRepository : RepositoryBase<Chude>, IChudeRepository
    {
        public ChudeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}