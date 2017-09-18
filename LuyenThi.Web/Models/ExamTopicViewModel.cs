using System;

namespace LuyenThi.Web.Models
{
    public class ExamTopicViewModel
    {
        public int TopicID { get; set; }

        public int ExamID { get; set; }

        public virtual ExamViewModel Exam { get; set; }

        public virtual TopicViewModel Topic { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string Note { get; set; }
    }
}