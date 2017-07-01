using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Dethi")]
    public class Dethi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Ten { get; set; }

        public virtual IEnumerable<DethiCauhoi> DethiCauhoi { get; set; }
        public virtual IEnumerable<ChudeDethi> ChudeDethi { get; set; }
    }
}