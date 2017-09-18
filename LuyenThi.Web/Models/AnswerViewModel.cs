using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuyenThi.Web.Models
{
    public class AnswerViewModel
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public string Content { get; set; }

        public string Code { get; set; }

        public int Order { get; set; }

        public Boolean TrueAnswer { get; set; }

        public string Image { get; set; }

        public virtual QuestionViewModel Question { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string Note { get; set; }
    }
}