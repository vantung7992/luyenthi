using LuyenThi.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Dapan")]
    public class Dapan : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Noidung { get; set; }

        [Required]
        [MaxLength(3)]
        public string Ma { get; set; }

        [Required]
        public int Thutu { get; set; }

        [Required]
        public Boolean Dungsai { get; set; }

        public int IDCauhoi { get; set; }

        public string Photo { get; set; }

        [ForeignKey("IDCauhoi")]
        public virtual Cauhoi Cauhoi { get; set; }
    }
}