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
    public class TinController : ApiController
    {
        private NewsWebsite db = new NewsWebsite();

        [HttpGet]
        public IHttpActionResult getNews_Feature()
        {
            var result = db.Tins.Where(x => x.TinNoiBat == 0).Take(8).ToList();
            if(result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getNews_Latest()
        {
            var result = db.Tins.OrderByDescending(x => x.idTin).Take(6).ToList();
            if (result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getNews_Random()
        {
            var result = db.Tins.OrderBy(r => Guid.NewGuid()).Take(10).ToList();
            if (result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getNews_MostView()
        {
            var result = db.Tins.OrderByDescending(x => x.SoLanXem).Take(5).ToList();
            if (result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getNewsByID(int id)
        {
            var result = db.Tins.Find(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getNewsByidLT(int id)
        {
            var nextPost = db.Tins.OrderBy(r => Guid.NewGuid()).First(x => x.idLT == id);
            var prevPost = db.Tins.OrderBy(r => Guid.NewGuid()).First(x => x.idLT == id);
            var listTin = db.Tins.Where(x => x.idLT == id).OrderBy(r => Guid.NewGuid()).Take(6).ToList();
            if(nextPost != null && prevPost != null && listTin != null && listTin.Any())
            {
                ViewModelTin data = new ViewModelTin(listTin, nextPost, prevPost);
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getNewsByidLT_All(int id)
        {
            var result = db.Tins.Where(x => x.idLT == id).ToList();
            if(result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpPost]
        public int InsertPost(JObject post)
        {
            try
            {
                var posttitle = post["title"].ToString();
                while (posttitle.Contains("  "))
                {
                    posttitle.Replace("  ", " ");
                }
                posttitle = TienIchController.RemoveUnicode(posttitle);
                posttitle = posttitle.Replace(" ", "-");
                Tin data = new Tin();
                data.TieuDe = post["title"].ToString();
                data.TieuDe_KhongDau = posttitle;
                data.urlHinh = post["image"].ToString();
                data.idTL = (int)post["cate"];
                data.idLT = (int)post["subcate"];
                data.Ngay = DateTime.Now;
                data.TinNoiBat = (byte)post["hot"];
                data.TomTat = post["summary"].ToString();
                data.AnHien = (byte)post["active"];
                data.Content = post["content"].ToString();
                db.Tins.Add(data);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int UpdatePost(JObject post)
        {
            try
            {
                var posttitle = post["title"].ToString();
                while (posttitle.Contains("  "))
                {
                    posttitle.Replace("  ", " ");
                }
                posttitle = TienIchController.RemoveUnicode(posttitle);
                posttitle = posttitle.Replace(" ", "-");
                var data = db.Tins.Find(post["id"]);
                data.TieuDe = post["title"].ToString();
                data.TieuDe_KhongDau = posttitle;
                data.urlHinh = post["image"].ToString();
                data.idTL = (int)post["cate"];
                data.idLT = (int)post["subcate"];
                data.TinNoiBat = (byte)post["hot"];
                data.TomTat = post["summary"].ToString();
                data.AnHien = (byte)post["active"];
                data.Content = post["content"].ToString();
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int DeletePost(int id)
        {
            try
            {
                var post = db.Tins.Find(id);
                db.Tins.Remove(post);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //[HttpGet]
        //public IHttpActionResult getTinTheoidLT(int id)
        //{
        //    return Ok(db.Tins.Where(x => x.idLT == id).OrderBy(r => Guid.NewGuid()).Take(6).ToList());
        //}

        //[HttpGet]
        //public IHttpActionResult getTinNextTheoidLT(int id)
        //{
        //    return Ok(db.Tins.OrderBy(r => Guid.NewGuid()).First(x => x.idLT == id));
        //}

        //[HttpGet]
        //public IHttpActionResult getTinPrevTheoidLT(int id)
        //{
        //    return Ok(db.Tins.OrderBy(r => Guid.NewGuid()).First(x => x.idLT == id));
        //}
    }
}
