using System;

namespace LuyenThi.Web.Models
{
    public class ChudeDethiViewModel
    {
        public int IDChude { get; set; }

        public int IDDethi { get; set; }

        public virtual DethiViewModel Dethi { get; set; }

        public virtual ChudeViewModel Chude { get; set; }

        public string Tag { get; set; }

        public bool Trangthai { get; set; }

        public DateTime? Ngaytao { get; set; }

        public string Nguoitao { get; set; }

        public DateTime? Ngaysua { get; set; }

        public string Nguoisua { get; set; }

        public string Ghichu { get; set; }
    }
}