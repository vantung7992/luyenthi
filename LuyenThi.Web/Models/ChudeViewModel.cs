using System;

namespace LuyenThi.Web.Models
{
    public class ChudeViewModel
    {
        public int ID { get; set; }

        public string Ten { get; set; }

        public string Tag { get; set; }

        public int? IDChudeCha { get; set; }

        public string Seo { get; set; }

        public string Mota { get; set; }

        public string Image { get; set; }

        public bool Trangthai { get; set; }

        public DateTime? Ngaytao { get; set; }

        public string Nguoitao { get; set; }

        public DateTime? Ngaysua { get; set; }

        public string Nguoisua { get; set; }

        public string Ghichu { get; set; }
    }
}