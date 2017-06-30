using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuyenThi.Data.Repositories
{
    public interface IDethiCauhoiRepository { }
    public class DethiCauhoirepository : RepositoryBase<DethiCauhoi>, IDethiCauhoiRepository
    {
        public DethiCauhoirepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
