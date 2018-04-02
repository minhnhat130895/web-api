namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTin")]
    public partial class LoaiTin
    {
        [Key]
        public int idLT { get; set; }

        [Required]
        [StringLength(255)]
        public string Ten { get; set; }

        [Required]
        [StringLength(255)]
        public string Ten_KhongDau { get; set; }

        public byte ThuTu { get; set; }

        public byte AnHien { get; set; }

        public int idTL { get; set; }
    }
}
