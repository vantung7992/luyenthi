using System;

namespace LuyenThi.Web.Models
{
    public class ChudeCauhoiViewModel
    {
        public int IDChude { get; set; }

        public int IDCauhoi { get; set; }

        public int Thutu { get; set; }

        public virtual ChudeViewModel Chude { get; set; }

        public virtual CauhoiViewModel Cauhoi { get; set; }

        public string Tag { get; set; }

        public bool Trangthai { get; set; }

        public DateTime? Ngaytao { get; set; }

        public string Nguoitao { get; set; }

        public DateTime? Ngaysua { get; set; }

        public string Nguoisua { get; set; }

        public string Ghichu { get; set; }
    }
}