using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuyenThi.Web.Models
{
    public class DethiCauhoiViewModel
    {
        public int IDDethi { get; set; }
        public int IDCauhoi { get; set; }

        public int Thutu { get; set; }

        public virtual CauhoiViewModel Cauhoi { get; set; }

        public virtual DethiViewModel Dethi { get; set; }

        public string Tag { get; set; }

        public bool Trangthai { get; set; }

        public DateTime? Ngaytao { get; set; }

        public string Nguoitao { get; set; }

        public DateTime? Ngaysua { get; set; }

        public string Nguoisua { get; set; }

        public string Ghichu { get; set; }
    }
}