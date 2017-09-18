using LuyenThi.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Answers")]
    public class Answer : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int QuestionID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(3)]
        public string Code { get; set; }

        [Required]
        public int Order { get; set; }

        public Boolean TrueAnswer { get; set; }

        public string Image { get; set; }

        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }
    }
}