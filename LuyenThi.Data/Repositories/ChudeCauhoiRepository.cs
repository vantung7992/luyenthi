using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuyenThi.Data.Repositories
{
    public interface IChudeCauhoiRepository { }
    public class ChudeCauhoiRepository : RepositoryBase<ChudeCauhoi>, IChudeCauhoiRepository
    {
        public ChudeCauhoiRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
