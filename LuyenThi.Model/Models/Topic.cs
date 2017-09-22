using LuyenThi.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Topics")]
    public class Topic : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int? ParentID { get; set; }

        [MaxLength(200)]
        public string Seo { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Tag { get; set; }

        [Column(TypeName ="ntext")]
        public string Description { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }
    }
}