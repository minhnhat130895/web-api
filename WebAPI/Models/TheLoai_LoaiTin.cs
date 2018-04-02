using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TheLoai_LoaiTin
    {
        public TheLoai_LoaiTin(TheLoai theloai, LoaiTin loaitin)
        {
            idTL = theloai.idTL;
            TenTL = theloai.TenTL;
            TenTL_KhongDau = theloai.TenTL_KhongDau;
            ThuTu = theloai.ThuTu;
            AnHien = theloai.AnHien;
            this.loaitin = loaitin;
        }

        public int idTL { get; set; }

        public string TenTL { get; set; }

        public string TenTL_KhongDau { get; set; }

        public int? ThuTu { get; set; }

        public byte? AnHien { get; set; }

        public LoaiTin loaitin { get; set; }
    }
}