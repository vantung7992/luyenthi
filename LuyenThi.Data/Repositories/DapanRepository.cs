using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuyenThi.Data.Repositories
{
    public interface IDapanRepository { }
    public class DapanRepository : RepositoryBase<Dapan>
    {
        public DapanRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
