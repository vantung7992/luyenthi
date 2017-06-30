using System;

namespace LuyenThi.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? Ngaytao { get; set; }
        string Nguoitao { get; set; }
        DateTime? Ngaysua { get; set; }
        string Nguoisua { get; set; }
        string Ghichu { get; set; }
    }
}