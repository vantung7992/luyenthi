namespace LuyenThi.Web.Models
{
    public class ChudeCauhoiViewModel
    {
        public int IDChude { get; set; }

        public int IDCauhoi { get; set; }

        public int Thutu { get; set; }

        public virtual ChudeViewModel Chude { get; set; }

        public virtual CauhoiViewModel Cauhoi { get; set; }
    }
}