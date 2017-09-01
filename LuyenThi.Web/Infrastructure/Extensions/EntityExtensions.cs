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
            chude.IDChudeCha = chudeViewModel.IDChudeCha;
            chude.Seo = chudeViewModel.Seo;
            chude.Mota = chudeViewModel.Mota;
            chude.HomeFlag = chudeViewModel.HomeFlag;

            chude.Trangthai = chudeViewModel.Trangthai;
            chude.Ngaytao = chudeViewModel.Ngaytao;
            chude.Nguoitao = chudeViewModel.Nguoitao;
            chude.Ngaysua = chudeViewModel.Ngaysua;
            chude.Nguoisua = chudeViewModel.Nguoisua;
            chude.Ghichu = chudeViewModel.Ghichu;
            chude.Image = chudeViewModel.Image;
        }

        public static void UpdateDethi(this Dethi dethi, DethiViewModel dethiViewModel)
        {
            dethi.ID = dethiViewModel.ID;
            dethi.Ten = dethiViewModel.Ten;
            dethi.Tag = dethiViewModel.Tag;
            dethi.Trangthai = dethiViewModel.Trangthai;
            dethi.Ngaytao = dethiViewModel.Ngaytao;
            dethi.Nguoitao = dethiViewModel.Nguoitao;
            dethi.Ngaysua = dethiViewModel.Ngaysua;
            dethi.Nguoisua = dethiViewModel.Nguoisua;
            dethi.Ghichu = dethiViewModel.Ghichu;
        }

        public static void UpdateCauhoi(this Cauhoi cauhoi, CauhoiViewModel cauhoiViewModel)
        {
            cauhoi.ID = cauhoiViewModel.ID;
            cauhoi.Noidung = cauhoiViewModel.Noidung;
            cauhoi.Noidunghienthi = cauhoiViewModel.Noidunghienthi;
            cauhoi.Goiy = cauhoiViewModel.Goiy;
            cauhoi.Tag = cauhoiViewModel.Tag;
            cauhoi.Image = cauhoiViewModel.Image;

            cauhoi.Trangthai = cauhoiViewModel.Trangthai;
            cauhoi.Ngaytao = cauhoiViewModel.Ngaytao;
            cauhoi.Nguoitao = cauhoiViewModel.Nguoitao;
            cauhoi.Ngaysua = cauhoiViewModel.Ngaysua;
            cauhoi.Nguoisua = cauhoiViewModel.Nguoisua;
            cauhoi.Ghichu = cauhoiViewModel.Ghichu;
        }

        public static void UpdateDapan(this Dapan dapan, DapanViewModel dapanViewModel)
        {
            dapan.ID = dapanViewModel.ID;
            dapan.Noidung = dapanViewModel.Noidung;
            dapan.Ma = dapanViewModel.Ma;
            dapan.Thutu = dapanViewModel.Thutu;
            dapan.Dungsai = dapanViewModel.Dungsai;
            dapan.IDCauhoi = dapanViewModel.IDCauhoi;
            dapan.Image = dapanViewModel.Image;

            dapan.Trangthai = dapanViewModel.Trangthai;
            dapan.Ngaytao = dapanViewModel.Ngaytao;
            dapan.Nguoitao = dapanViewModel.Nguoitao;
            dapan.Ngaysua = dapanViewModel.Ngaysua;
            dapan.Nguoisua = dapanViewModel.Nguoisua;
            dapan.Ghichu = dapanViewModel.Ghichu;
        }

        public static void UpdateChudeCauhoi(this ChudeCauhoi chudeCauhoi, ChudeCauhoiViewModel chudeCauhoiViewModel)
        {
            chudeCauhoi.IDChude = chudeCauhoiViewModel.IDChude;
            chudeCauhoi.IDCauhoi = chudeCauhoiViewModel.IDCauhoi;
            chudeCauhoi.Thutu = chudeCauhoiViewModel.Thutu;

            chudeCauhoi.Trangthai = chudeCauhoiViewModel.Trangthai;
            chudeCauhoi.Ngaytao = chudeCauhoiViewModel.Ngaytao;
            chudeCauhoi.Nguoitao = chudeCauhoiViewModel.Nguoitao;
            chudeCauhoi.Ngaysua = chudeCauhoiViewModel.Ngaysua;
            chudeCauhoi.Nguoisua = chudeCauhoiViewModel.Nguoisua;
            chudeCauhoi.Ghichu = chudeCauhoiViewModel.Ghichu;
        }

        public static void UpdateChudeDethi(this ChudeDethi chudeDethi, ChudeDethiViewModel chudeDethiViewModel)
        {
            chudeDethi.IDChude = chudeDethiViewModel.IDChude;
            chudeDethi.IDDethi = chudeDethiViewModel.IDDethi;

            chudeDethi.Trangthai = chudeDethiViewModel.Trangthai;
            chudeDethi.Ngaytao = chudeDethiViewModel.Ngaytao;
            chudeDethi.Nguoitao = chudeDethiViewModel.Nguoitao;
            chudeDethi.Ngaysua = chudeDethiViewModel.Ngaysua;
            chudeDethi.Nguoisua = chudeDethiViewModel.Nguoisua;
            chudeDethi.Ghichu = chudeDethiViewModel.Ghichu;
        }

        public static void UpdateDethiCauhoi(this DethiCauhoi dethiCauhoi, DethiCauhoiViewModel dethiCauhoiViewModel)
        {
            dethiCauhoi.IDDethi = dethiCauhoiViewModel.IDDethi;
            dethiCauhoi.IDCauhoi = dethiCauhoiViewModel.IDCauhoi;
            dethiCauhoi.Thutu = dethiCauhoiViewModel.Thutu;

            dethiCauhoi.Trangthai = dethiCauhoiViewModel.Trangthai;
            dethiCauhoi.Ngaytao = dethiCauhoiViewModel.Ngaytao;
            dethiCauhoi.Nguoitao = dethiCauhoiViewModel.Nguoitao;
            dethiCauhoi.Ngaysua = dethiCauhoiViewModel.Ngaysua;
            dethiCauhoi.Nguoisua = dethiCauhoiViewModel.Nguoisua;
            dethiCauhoi.Ghichu = dethiCauhoiViewModel.Ghichu;
        }
    }
}