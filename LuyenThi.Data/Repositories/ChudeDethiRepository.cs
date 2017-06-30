using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IChudeDethiRepositiry { }

    public class ChudeDethiRepository : RepositoryBase<ChudeDethi>, IChudeDethiRepositiry
    {
        public ChudeDethiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}