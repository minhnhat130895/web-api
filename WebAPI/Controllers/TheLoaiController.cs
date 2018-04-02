using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TheLoaiController : ApiController
    {
        private NewsWebsite db = new NewsWebsite();

        [HttpGet]
        public IHttpActionResult getCateAll()
        {
            var result = db.TheLoais.ToList();
            if (result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getCateByID(int id)
        {
            var result = db.TheLoais.Find(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getCate_Newest()
        {
            var data = db.TheLoais.OrderByDescending(x => x.ThuTu).First();
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getCate_SubCate(int id)
        {
            var LoaiTin = db.LoaiTins.Find(id);
            var TheLoai = db.TheLoais.Find(LoaiTin.idTL);
            if (LoaiTin != null && TheLoai != null)
            {
                TheLoai_LoaiTin data = new TheLoai_LoaiTin(TheLoai, LoaiTin);
                return Ok(data);
            }
            return NotFound();
        }

        [HttpPost]
        public int InsertCate(JObject cate)
        {
            try
            {
                var catetitle = cate["catename"].ToString();
                while (catetitle.Contains("  "))
                {
                    catetitle.Replace("  ", " ");
                }
                catetitle = TienIchController.RemoveUnicode(catetitle);
                catetitle = catetitle.Replace(" ", "-");
                TheLoai data = new TheLoai();
                data.TenTL = cate["catename"].ToString();
                data.TenTL_KhongDau = catetitle;
                data.AnHien = (byte)cate["cateactive"];
                data.ThuTu = (int)cate["catenumber"];
                db.TheLoais.Add(data);
                db.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int UpdateCate(JObject cate)
        {
            try
            {
                var catetitle = cate["catename"].ToString();
                while (catetitle.Contains("  "))
                {
                    catetitle.Replace("  ", " ");
                }
                catetitle = TienIchController.RemoveUnicode(catetitle);
                catetitle = catetitle.Replace(" ", "-");
                var data = db.TheLoais.Find(cate["cateid"]);
                data.TenTL = cate["catename"].ToString();
                data.TenTL_KhongDau = catetitle;
                data.AnHien = (byte)cate["cateactive"];
                data.ThuTu = (int)cate["catenumber"];
                db.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int DeleteCate(int id)
        {
            try
            {
                var cate = db.TheLoais.Find(id);
                db.TheLoais.Remove(cate);
                db.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

    }
}
