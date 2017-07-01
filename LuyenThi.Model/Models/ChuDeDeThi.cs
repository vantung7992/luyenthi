using LuyenThi.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("ChudeDethi")]
    public class ChudeDethi : Auditable
    {
        [Key]
        [Column(Order =1)]
        public int IDChude { get; set; }

        [Key]
        [Column(Order =2)]
        public int IDDethi { get; set; }

        [ForeignKey("IDDethi")]
        public virtual Dethi Dethi { get; set; }

        [ForeignKey("IDChude")]
        public virtual Chude Chude { get; set; }
    }
}