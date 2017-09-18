using System;

namespace LuyenThi.Web.Models
{
    public class ExamDetailViewModel
    {
        public int ExamID { get; set; }
        public int QuestionID { get; set; }

        public int Order { get; set; }

        public virtual QuestionViewModel Question { get; set; }

        public virtual ExamViewModel Exam { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string Note { get; set; }
    }
}