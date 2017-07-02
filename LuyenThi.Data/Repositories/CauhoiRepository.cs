using LuyenThi.Data.Infrastructure;
using LuyenThi.Model.Models;
using System;
using System.Collections;
using System.Linq;

namespace LuyenThi.Data.Repositories
{
    public interface ICauhoiRepository : IRepository<Cauhoi>
    {
        IEnumerable GetAllByChude(int idChude);

        IEnumerable GetAllbyDethi(int idDethi);
    }

    public class CauhoiRepository : RepositoryBase<Cauhoi>, ICauhoiRepository
    {
        public CauhoiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable GetAllByChude(int idChude)
        {
            var query = from c in DbContext.Cauhoi
                        join cc in DbContext.ChudeCauhoi
                        on c.ID equals cc.IDCauhoi
                        where cc.IDChude == idChude && c.Trangthai
                        orderby cc.Thutu ascending
                        select c;
            query.Count();
            return query;
        }

        public IEnumerable GetAllbyDethi(int idDethi)
        {
            var query = from c in DbContext.Cauhoi
                        join dc in DbContext.DethiCauhoi
                        on c.ID equals dc.IDCauhoi
                        where dc.IDDethi == idDethi && c.Trangthai
                        select c;
            return query;
        }
    }
}