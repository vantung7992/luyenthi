using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IExamDetailRepository : IRepository<ExamDetail> { }

    public class DethiCauhoiRepository : RepositoryBase<ExamDetail>, IExamDetailRepository
    {
        public DethiCauhoiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}