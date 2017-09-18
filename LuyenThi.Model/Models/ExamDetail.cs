using LuyenThi.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("ExamDetail")]
    public class ExamDetail : Auditable
    {
        [Key]
        [Column(Order = 1)]
        public int ExamID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int QuestionID { get; set; }

        [Required]
        public int Order { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }

        [ForeignKey("ExamID")]
        public virtual Exam Exam { get; set; }
    }
}