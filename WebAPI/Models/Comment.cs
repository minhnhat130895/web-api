namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string hoten { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string noidung { get; set; }

        public int idTin { get; set; }
    }
}
