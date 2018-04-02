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
    public class LoaiTinController : ApiController
    {
        private NewsWebsite db = new NewsWebsite();

        [HttpGet]
        public IHttpActionResult getSubCate_All()
        {
            var result = db.LoaiTins.ToList();
            if(result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getSubCateByID(int id)
        {
            var result = db.LoaiTins.Find(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getSubCate_Newest()
        {
            var data = db.LoaiTins.OrderByDescending(x => x.ThuTu).First();
            if (data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getCate_SubCateOfCate()
        {
            var listTheLoai = db.TheLoais.ToList();
            List<List<LoaiTin>> listLoaiTin = new List<List<LoaiTin>>();
            foreach(var item in listTheLoai)
            {
                var list = db.LoaiTins.Where(x => x.idTL == item.idTL).ToList();
                listLoaiTin.Add(list);
            }
            TheLoai_LoaiTinOfTheLoai data = new TheLoai_LoaiTinOfTheLoai(listTheLoai, listLoaiTin);
            if(data != null)
                return Ok(data);
            return NotFound();
        }

        [HttpPost]
        public int InsertSubCate(JObject cate)
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
                LoaiTin data = new LoaiTin();
                data.Ten = cate["catename"].ToString();
                data.Ten_KhongDau = catetitle;
                data.AnHien = (byte)cate["cateactive"];
                data.ThuTu = (byte)cate["catenumber"];
                data.idTL = (int)cate["cate"];
                db.LoaiTins.Add(data);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int UpdateSubCate(JObject cate)
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
                var data = db.LoaiTins.Find(cate["cateid"]);
                data.Ten = cate["catename"].ToString();
                data.Ten_KhongDau = catetitle;
                data.AnHien = (byte)cate["cateactive"];
                data.ThuTu = (byte)cate["catenumber"];
                data.idTL = (int)cate["cate"];
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int DeleteSubCate(int id)
        {
            try
            {
                var cate = db.LoaiTins.Find(id);
                db.LoaiTins.Remove(cate);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
