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
            chude.Tag = chudeViewModel.Tag;
            chude.Trangthai = chudeViewModel.Trangthai;
            chude.Ngaytao = chudeViewModel.Ngaytao;
            chude.Nguoitao = chudeViewModel.Nguoitao;
            chude.Ngaysua = chudeViewModel.Ngaysua;
            chude.Nguoisua = chudeViewModel.Nguoisua;
            chude.Ghichu = chudeViewModel.Ghichu;
        }

        public static void UpdateDethi(this Dethi dethi, DethiViewModel dethiViewModel)
        {
            dethi.ID = dethiViewModel.ID;
            dethi.Ten = dethiViewModel.Ten;

            dethi.Tag = dethi.Tag;
            dethi.Trangthai = dethi.Trangthai;
            dethi.Ngaytao = dethi.Ngaytao;
            dethi.Nguoitao = dethi.Nguoitao;
            dethi.Ngaysua = dethi.Ngaysua;
            dethi.Nguoisua = dethi.Nguoisua;
            dethi.Ghichu = dethi.Ghichu;
        }

        public static void UpdateCauhoi(this Cauhoi cauhoi, CauhoiViewModel cauhoiViewModel)
        {
            cauhoi.ID = cauhoiViewModel.ID;
            cauhoi.Noidung = cauhoiViewModel.Noidung;
            cauhoi.Photo = cauhoiViewModel.Photo;

            cauhoi.Tag = cauhoi.Tag;
            cauhoi.Trangthai = cauhoi.Trangthai;
            cauhoi.Ngaytao = cauhoi.Ngaytao;
            cauhoi.Nguoitao = cauhoi.Nguoitao;
            cauhoi.Ngaysua = cauhoi.Ngaysua;
            cauhoi.Nguoisua = cauhoi.Nguoisua;
            cauhoi.Ghichu = cauhoi.Ghichu;
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

            dapan.Tag = dapan.Tag;
            dapan.Trangthai = dapan.Trangthai;
            dapan.Ngaytao = dapan.Ngaytao;
            dapan.Nguoitao = dapan.Nguoitao;
            dapan.Ngaysua = dapan.Ngaysua;
            dapan.Nguoisua = dapan.Nguoisua;
            dapan.Ghichu = dapan.Ghichu;
        }

        public static void UpdateChudeCauhoi(this ChudeCauhoi chudeCauhoi, ChudeCauhoiViewModel chudeCauhoiViewModel)
        {
            chudeCauhoi.IDChude = chudeCauhoiViewModel.IDChude;
            chudeCauhoi.IDCauhoi = chudeCauhoiViewModel.IDCauhoi;
            chudeCauhoi.Thutu = chudeCauhoi.Thutu;

            chudeCauhoi.Tag = chudeCauhoi.Tag;
            chudeCauhoi.Trangthai = chudeCauhoi.Trangthai;
            chudeCauhoi.Ngaytao = chudeCauhoi.Ngaytao;
            chudeCauhoi.Nguoitao = chudeCauhoi.Nguoitao;
            chudeCauhoi.Ngaysua = chudeCauhoi.Ngaysua;
            chudeCauhoi.Nguoisua = chudeCauhoi.Nguoisua;
            chudeCauhoi.Ghichu = chudeCauhoi.Ghichu;
        }

        public static void UpdateChudeDethi(this ChudeDethi chudeDethi, ChudeDethiViewModel chudeDethiViewModel)
        {
            chudeDethi.IDChude = chudeDethiViewModel.IDChude;
            chudeDethi.IDDethi = chudeDethiViewModel.IDDethi;

            chudeDethi.Tag = chudeDethi.Tag;
            chudeDethi.Trangthai = chudeDethi.Trangthai;
            chudeDethi.Ngaytao = chudeDethi.Ngaytao;
            chudeDethi.Nguoitao = chudeDethi.Nguoitao;
            chudeDethi.Ngaysua = chudeDethi.Ngaysua;
            chudeDethi.Nguoisua = chudeDethi.Nguoisua;
            chudeDethi.Ghichu = chudeDethi.Ghichu;
        }

        public static void UpdateDethiCauhoi(this DethiCauhoi dethiCauhoi, DethiCauhoiViewModel dethiCauhoiViewModel)
        {
            dethiCauhoi.IDDethi = dethiCauhoiViewModel.IDDethi;
            dethiCauhoi.IDCauhoi = dethiCauhoiViewModel.IDCauhoi;
            dethiCauhoi.Thutu = dethiCauhoiViewModel.Thutu;

            dethiCauhoi.Tag = dethiCauhoi.Tag;
            dethiCauhoi.Trangthai = dethiCauhoi.Trangthai;
            dethiCauhoi.Ngaytao = dethiCauhoi.Ngaytao;
            dethiCauhoi.Nguoitao = dethiCauhoi.Nguoitao;
            dethiCauhoi.Ngaysua = dethiCauhoi.Ngaysua;
            dethiCauhoi.Nguoisua = dethiCauhoi.Nguoisua;
            dethiCauhoi.Ghichu = dethiCauhoi.Ghichu;
        }

        public static void UpdateChudeCauhoi(this ChudeCauhoi chudeCauhoi, ChudeCauhoiViewModel chudeCauhoiViewModel)
        {
            chudeCauhoi.IDChude = chudeCauhoiViewModel.IDChude;
            chudeCauhoi.IDCauhoi = chudeCauhoiViewModel.IDCauhoi;
            chudeCauhoi.Thutu = chudeCauhoiViewModel.Thutu;
        }

        public static void UpdateChudeDethi(this ChudeDethi chudeDethi, ChudeDethiViewModel chudeDethiViewmodel)
        {
            chudeDethi.IDChude = chudeDethiViewmodel.IDChude;
            chudeDethi.IDDethi = chudeDethiViewmodel.IDDethi;
        }
    }
}