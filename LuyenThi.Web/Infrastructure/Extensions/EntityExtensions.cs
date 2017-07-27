using LuyenThi.Model.Models;
using LuyenThi.Web.Models;

namespace LuyenThi.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateChude(this Chude chude, ChudeViewModel chudeViewModel)
        {
            chude.ID = chudeViewModel.ID;
            chude.Ten = chudeViewModel.Ten;
        }

        public static void UpdateDethi(this Dethi dethi, DethiViewModel dethiViewModel)
        {
            dethi.ID = dethiViewModel.ID;
            dethi.Ten = dethiViewModel.Ten;
        }

        public static void UpdateCauhoi(this Cauhoi cauhoi, CauhoiViewModel cauhoiViewModel)
        {
            cauhoi.ID = cauhoiViewModel.ID;
            cauhoi.Noidung = cauhoiViewModel.Noidung;
            cauhoi.Photo = cauhoiViewModel.Photo;
        }

        public static void UpdateDapan(this Dapan dapan, DapanViewModel dapanViewModel)
        {
            dapan.ID = dapanViewModel.ID;
            dapan.Noidung = dapanViewModel.Noidung;
            dapan.Ma = dapanViewModel.Ma;
            dapan.Thutu = dapanViewModel.Thutu;
            dapan.Dungsai = dapanViewModel.Dungsai;
            dapan.IDCauhoi = dapanViewModel.IDCauhoi;
            dapan.Photo = dapanViewModel.Photo;
        }
    }
}