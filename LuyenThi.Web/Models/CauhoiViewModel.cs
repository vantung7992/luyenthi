using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuyenThi.Web.Models
{
    public class CauhoiViewModel
    {
        public int ID { get; set; }

        public string Noidung { get; set; }

        public string Photo { get; set; }

        public virtual IEnumerable<DethiCauhoiViewModel> DethiCauhoi { get; set; }
        public virtual IEnumerable<DapanViewModel> DanhsachDapan { get; set; }
    }
}