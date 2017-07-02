using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IDethiCauhoiRepository : IRepository<DethiCauhoi> { }

    public class DethiCauhoirepository : RepositoryBase<DethiCauhoi>, IDethiCauhoiRepository
    {
        public DethiCauhoirepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}