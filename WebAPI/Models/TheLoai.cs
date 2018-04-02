namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheLoai")]
    public partial class TheLoai
    {
        [Key]
        public int idTL { get; set; }

        [Required]
        [StringLength(255)]
        public string TenTL { get; set; }

        [Required]
        [StringLength(255)]
        public string TenTL_KhongDau { get; set; }

        public int? ThuTu { get; set; }

        public byte? AnHien { get; set; }
    }
}
