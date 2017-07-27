using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuyenThi.Web.Models
{
    public class DethiViewModel
    {
        public int ID { get; set; }

        public string Ten { get; set; }

        public virtual IEnumerable<DethiCauhoiViewModel> DethiCauhoi { get; set; }
        public virtual IEnumerable<ChudeDethiViewModel> ChudeDethi { get; set; }
    }
}