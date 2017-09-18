using LuyenThi.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("ExamTopics")]
    public class ExamTopic : Auditable
    {
        [Key]
        [Column(Order = 1)]
        public int TopicID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ExamID { get; set; }

        [ForeignKey("ExamID")]
        public virtual Exam Exam { get; set; }

        [ForeignKey("TopicID")]
        public virtual Topic Topic { get; set; }
    }
}