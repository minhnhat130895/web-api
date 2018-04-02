namespace WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewsWebsite : DbContext
    {
        public NewsWebsite()
            : base("name=NewsWebsiteDbContext")
        {
        }

        public virtual DbSet<BinhChon> BinhChons { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<LienKet> LienKets { get; set; }
        public virtual DbSet<LoaiTin> LoaiTins { get; set; }
        public virtual DbSet<PhuongAn> PhuongAns { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<SuKien> SuKiens { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<Tin> Tins { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.noidung)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<LienKet>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiTin>()
                .Property(e => e.Ten_KhongDau)
                .IsUnicode(false);

            modelBuilder.Entity<QuangCao>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<QuangCao>()
                .Property(e => e.urlHinh)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.TenTL_KhongDau)
                .IsUnicode(false);

            modelBuilder.Entity<Tin>()
                .Property(e => e.TieuDe_KhongDau)
                .IsUnicode(false);

            modelBuilder.Entity<Tin>()
                .Property(e => e.urlHinh)
                .IsUnicode(false);

            modelBuilder.Entity<Tin>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.DiaChi)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.RandomKey)
                .IsUnicode(false);
        }
    }
}
