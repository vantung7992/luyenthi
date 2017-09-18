using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;

namespace LuyenThi.Data.Repositories
{
    public interface ITopicRepository : IRepository<Topic>
    {
    }

    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        public TopicRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}