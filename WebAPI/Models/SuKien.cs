namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuKien")]
    public partial class SuKien
    {
        [Key]
        public int idSK { get; set; }

        [Required]
        [StringLength(255)]
        public string MoTa { get; set; }
    }
}
