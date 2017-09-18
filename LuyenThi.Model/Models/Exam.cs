using LuyenThi.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Exams")]
    public class Exam : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Seo { get; set; }

        [MaxLength(1000)]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Image { get; set; }


        public int? TimeToDo { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Tag { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public virtual IEnumerable<ExamDetail> ExamDetail { get; set; }
        public virtual IEnumerable<ExamTopic> ExamTopic { get; set; }
    }
}