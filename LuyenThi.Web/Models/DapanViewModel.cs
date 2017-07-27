using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuyenThi.Web.Models
{
    public class DapanViewModel
    {
        public int ID { get; set; }

        public string Noidung { get; set; }

        public string Ma { get; set; }

        public int Thutu { get; set; }

        public Boolean Dungsai { get; set; }

        public int IDCauhoi { get; set; }

        public string Photo { get; set; }

        public virtual CauhoiViewModel Cauhoi { get; set; }
    }
}