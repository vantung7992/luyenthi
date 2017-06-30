using LuyenThi.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("ChudeCauhoi")]
    public class ChudeCauhoi :Auditable
    {
        [Key]
        public int IDChude { get; set; }

        [Key]
        public int IDCauhoi { get; set; }

        [Required]
        public int Thuhu { get; set; }

        [ForeignKey("IDChude")]
        public virtual Chude ChuDe { get; set; }

        [ForeignKey("IDCauhoi")]
        public virtual Cauhoi CauHoi { get; set; }
    }
}