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
    }
}