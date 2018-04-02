namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tin")]
    public partial class Tin
    {
        [Key]
        public int idTin { get; set; }

        [Required]
        [StringLength(500)]
        public string TieuDe { get; set; }

        [Required]
        [StringLength(500)]
        public string TieuDe_KhongDau { get; set; }

        [StringLength(1200)]
        public string TomTat { get; set; }

        [StringLength(255)]
        public string urlHinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public int idUser { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public int idLT { get; set; }

        public int? idTL { get; set; }

        public int? SoLanXem { get; set; }

        public byte? TinNoiBat { get; set; }

        public byte? AnHien { get; set; }
    }
}
