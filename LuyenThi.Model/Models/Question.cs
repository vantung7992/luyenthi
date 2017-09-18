using LuyenThi.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Questions")]
    public class Question : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int TopicID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string DisplayContent { get; set; }

        [MaxLength(1000)]
        public string Suggest { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Tag { get; set; }

        public virtual Topic Topic { get; set; }

        public virtual IEnumerable<ExamDetail> ExamDetail { get; set; }

        public virtual IEnumerable<Answer> Answers { get; set; }
    }
}