using LuyenThi.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Cauhoi")]
    public class Cauhoi : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Noidung { get; set; }

        [MaxLength(256)]
        public string Photo { get; set; }

        public virtual IEnumerable<DethiCauhoi> DethiCauhoi { get; set; }
        public virtual IEnumerable<Dapan> DanhsachDapan { get; set; }
    }
}