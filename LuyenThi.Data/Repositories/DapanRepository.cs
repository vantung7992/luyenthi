using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IDapanRepository : IRepository<Dapan> { }

    public class DapanRepository : RepositoryBase<Dapan>
    {
        public DapanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}