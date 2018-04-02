namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhChon")]
    public partial class BinhChon
    {
        [Key]
        public int idBC { get; set; }

        [Required]
        [StringLength(500)]
        public string MoTa { get; set; }
    }
}
