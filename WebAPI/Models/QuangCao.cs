namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuangCao")]
    public partial class QuangCao
    {
        [Key]
        public int idQC { get; set; }

        public int vitri { get; set; }

        [Required]
        [StringLength(500)]
        public string MoTa { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }

        [Required]
        [StringLength(255)]
        public string urlHinh { get; set; }

        public int SoLanClick { get; set; }
    }
}
