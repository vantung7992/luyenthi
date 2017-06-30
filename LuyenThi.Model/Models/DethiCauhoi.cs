using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("DethiCauHoi")]
    public class DethiCauhoi
    {
        [Key]
        public int IDDethi { get; set; }

        [Key]
        public int IDCauhoi { get; set; }

        [Required]
        public int Thutu { get; set; }

        [ForeignKey("IDCauhoi")]
        public virtual Cauhoi Cauhoi { get; set; }

        [ForeignKey("IDDethi")]
        public virtual Dethi Dethi { get; set; }
    }
}