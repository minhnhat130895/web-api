namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuongAn")]
    public partial class PhuongAn
    {
        [Key]
        public int idPA { get; set; }

        [Required]
        [StringLength(255)]
        public string Mota { get; set; }

        public int? SoLanChon { get; set; }

        public int idBC { get; set; }
    }
}
