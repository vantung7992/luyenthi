using AutoMapper;
using LuyenThi.Model.Models;
using LuyenThi.Web.Models;

namespace LuyenThi.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Chude, ChudeViewModel>();
                cfg.CreateMap<Dethi, DethiViewModel>();
                cfg.CreateMap<Cauhoi, CauhoiViewModel>();
                cfg.CreateMap<Dapan, DapanViewModel>();
                cfg.CreateMap<ChudeCauhoi, ChudeCauhoiViewModel>();
                cfg.CreateMap<ChudeDethi, ChudeDethiViewModel>();
            });
        }
    }
}