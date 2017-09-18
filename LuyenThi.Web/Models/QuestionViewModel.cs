using System;
using System.Collections.Generic;

namespace LuyenThi.Web.Models
{
    public class QuestionViewModel
    {
        public int ID { get; set; }

        public int TopicID { get; set; }

        public string Content { get; set; }

        public string DisplayContent { get; set; }

        public string Suggest { get; set; }

        public string Image { get; set; }

        public string Tag { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string Note { get; set; }

        public string StringJsonAnswer { get; set; }

        public virtual IEnumerable<ExamDetailViewModel> ExamDetail { get; set; }

        public virtual IEnumerable<AnswerViewModel> Answers { get; set; }
    }
}