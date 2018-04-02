using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TheLoai_LoaiTinOfTheLoai
    {
        public List<TheLoai> listTheLoai {get; set;}
        public List<List<LoaiTin>> listLoaiTin { get; set; }

        public TheLoai_LoaiTinOfTheLoai(List<TheLoai> listTheLoai, List<List<LoaiTin>> listLoaiTin)
        {
            this.listTheLoai = listTheLoai;
            this.listLoaiTin = listLoaiTin;
        }
    }
}