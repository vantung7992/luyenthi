using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;
using System.Collections;
using System;
using System.Linq;

namespace LuyenThi.Data.Repositories
{
    public interface IDethiRepository : IRepository<Dethi>
    {
        IEnumerable GetAllByChude(int idChude, int pageIndex, int pageSize, out int totalRow);
    }

    public class DethiRepository : RepositoryBase<Dethi>, IDethiRepository
    {
        public DethiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable GetAllByChude(int idChude, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from d in DbContext.Dethi
                        join cd in DbContext.ChudeDethi
                        on d.ID equals cd.IDDethi
                        where cd.IDChude == idChude && d.Trangthai
                        select d;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}