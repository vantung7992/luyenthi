using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuyenThi.Web.Models
{
    public class ChudeDethiViewModel
    {
        public int IDChude { get; set; }

        public int IDDethi { get; set; }

        public virtual DethiViewModel Dethi { get; set; }

        public virtual ChudeViewModel Chude { get; set; }
    }
}