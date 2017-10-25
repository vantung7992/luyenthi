using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IExamDetailRepository : IRepository<ExamDetail> { }

    public class ExamDetailRepository : RepositoryBase<ExamDetail>, IExamDetailRepository
    {
        public ExamDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}