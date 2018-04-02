namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string NoiDung { get; set; }
    }
}
