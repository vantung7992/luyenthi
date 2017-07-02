using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IChudeCauhoiRepository : IRepository<ChudeCauhoi> { }

    public class ChudeCauhoiRepository : RepositoryBase<ChudeCauhoi>, IChudeCauhoiRepository
    {
        public ChudeCauhoiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}