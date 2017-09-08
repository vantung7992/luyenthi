using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IDethiCauhoiRepository : IRepository<DethiCauhoi> { }

    public class DethiCauhoiRepository : RepositoryBase<DethiCauhoi>, IDethiCauhoiRepository
    {
        public DethiCauhoiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}