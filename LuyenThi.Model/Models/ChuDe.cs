using LuyenThi.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Chude")]
    public class Chude : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Ten { get; set; }

        public int? IDChudeCha { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Tag { get; set; }

        [MaxLength(200)]
        public string Seo { get; set; }

        [MaxLength(1000)]
        public string Mota { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        public bool HomeFlag { get; set; }
    }
}