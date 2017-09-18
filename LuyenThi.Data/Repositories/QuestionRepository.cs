using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LuyenThi.Data.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetAllByTopic(int idChude);
        IEnumerable<Question> GetAllbyExam(int idDethi);
    }

    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Question> GetAllByTopic(int topicID)
        {
            var query = DbContext.Question.Where(x => x.TopicID == topicID);
            return query;
        }

        public IEnumerable<Question> GetAllbyExam(int examID)
        {
            var query = from c in DbContext.Question
                        join dc in DbContext.ExamDetail
                        on c.ID equals dc.QuestionID
                        where dc.ExamID == examID && c.Status == true
                        select c;
            return query;
        }
    }
}