using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("DethiCauhoi")]
    public class DethiCauhoi
    {
        [Key]
        [Column(Order =1)]
        public int IDDethi { get; set; }

        [Key]
        [Column(Order =2)]
        public int IDCauhoi { get; set; }

        [Required]
        public int Thutu { get; set; }

        [ForeignKey("IDCauhoi")]
        public virtual Cauhoi Cauhoi { get; set; }

        [ForeignKey("IDDethi")]
        public virtual Dethi Dethi { get; set; }
    }
}