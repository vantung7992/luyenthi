using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface IExamTopicRepositiry : IRepository<ExamTopic> { }

    public class ExamTopicRepository : RepositoryBase<ExamTopic>, IExamTopicRepositiry
    {
        public ExamTopicRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}