using System;
using System.ComponentModel.DataAnnotations;

namespace LuyenThi.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public string Nhan { get; set; }

        public bool Trangthai { get; set; }

        public DateTime? Ngaytao { get; set; }

        [MaxLength(256)]
        public string Nguoitao { get; set; }

        public DateTime? Ngaysua { get; set; }

        [MaxLength(256)]
        public string Nguoisua { get; set; }

        [MaxLength(1000)]
        public string Ghichu { get; set; }
    }
}