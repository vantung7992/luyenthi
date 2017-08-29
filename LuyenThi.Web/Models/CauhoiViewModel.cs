using System;
using System.Collections.Generic;

namespace LuyenThi.Web.Models
{
    public class CauhoiViewModel
    {
        public int ID { get; set; }

        public string Noidung { get; set; }

        public string Goiy { get; set; }

        public string Image { get; set; }

        public string Tag { get; set; }

        public bool Trangthai { get; set; }

        public DateTime? Ngaytao { get; set; }

        public string Nguoitao { get; set; }

        public DateTime? Ngaysua { get; set; }

        public string Nguoisua { get; set; }

        public string Ghichu { get; set; }
        public string strJsonDapan { get; set; }

        public virtual IEnumerable<DethiCauhoiViewModel> DethiCauhoi { get; set; }
        public virtual IEnumerable<DapanViewModel> DanhsachDapan { get; set; }
    }
}