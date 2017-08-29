﻿using LuyenThi.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuyenThi.Model.Models
{
    [Table("Cauhoi")]
    public class Cauhoi : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Noidung { get; set; }

        [Required]
        [Column(TypeName ="ntext")]
        public string Noidunghienthi { get; set; }

        [MaxLength(1000)]
        public string Goiy { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Tag { get; set; }

        public virtual IEnumerable<DethiCauhoi> DethiCauhoi { get; set; }
        public virtual IEnumerable<Dapan> DanhsachDapan { get; set; }
    }
}