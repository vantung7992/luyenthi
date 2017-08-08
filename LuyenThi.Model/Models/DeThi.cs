using LuyenThi.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Dethi")]
    public class Dethi : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Ten { get; set; }

        [MaxLength(200)]
        public string Seo { get; set; }

        [MaxLength(500)]
        public string Mota { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Tag { get; set; }

        public virtual IEnumerable<DethiCauhoi> DethiCauhoi { get; set; }
        public virtual IEnumerable<ChudeDethi> ChudeDethi { get; set; }
    }
}