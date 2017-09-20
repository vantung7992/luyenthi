using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LuyenThi.Data.Repositories
{
    public interface IExamRepository : IRepository<Exam>
    {
        IEnumerable<Exam> GetAllByTopic(int idChude, int pageIndex, int pageSize, out int totalRow);
    }

    public class ExamRepository : RepositoryBase<Exam>, IExamRepository
    {
        public ExamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Exam> GetAllByTopic(int topicID, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from d in DbContext.Exam
                        join cd in DbContext.ExamTopic
                        on d.ID equals cd.ExamID
                        where cd.TopicID == topicID && d.Status == true
                        select d;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}