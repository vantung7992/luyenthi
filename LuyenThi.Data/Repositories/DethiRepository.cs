using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IDethiRepository { }

    public class DethiRepository : RepositoryBase<Dethi>, IDethiRepository
    {
        public DethiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}