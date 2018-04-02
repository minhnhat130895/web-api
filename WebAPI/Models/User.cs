namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public int idUser { get; set; }

        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string Dienthoai { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDangKy { get; set; }

        public int idGroup { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public byte? GioiTinh { get; set; }

        public int? Active { get; set; }

        [StringLength(255)]
        public string RandomKey { get; set; }
    }
}
