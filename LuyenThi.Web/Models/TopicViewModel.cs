using LuyenThi.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LuyenThi.Web.Models
{
    public class TopicViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? ParentID { get; set; }

        public string Description { get; set; }

        public string Seo { get; set; }

        public string Tag { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string Note { get; set; }

        public virtual IEnumerable<Question> Question { get; set; }
    }
}