using LuyenThi.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("ChudeCauhoi")]
    public class ChudeCauhoi :Auditable
    {
        [Key]
        [Column(Order =1)]
        public int IDChude { get; set; }

        [Key]
        [Column(Order =2)]
        public int IDCauhoi { get; set; }

        [Required]
        public int Thutu { get; set; }

        [ForeignKey("IDChude")]
        public virtual Chude Chude { get; set; }

        [ForeignKey("IDCauhoi")]
        public virtual Cauhoi Cauhoi { get; set; }
    }
}