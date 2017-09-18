using System;

namespace LuyenThi.Model.Abstract
{
    public interface IAuditable
    {
        bool? Status { get; set; }
        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
        string Note { get; set; }
    }
}