using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuyenThi.Model.Models;
using LuyenThi.Data.Infrastructure;

namespace LuyenThi.Data.Repositories
{
    public interface ICauhoiRepository { }
    public class CauhoiRepository : RepositoryBase<Cauhoi>, ICauhoiRepository
    {
        public CauhoiRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
