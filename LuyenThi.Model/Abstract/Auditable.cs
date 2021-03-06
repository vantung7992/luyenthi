﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LuyenThi.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public bool? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        public string UpdatedBy { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }
    }
}