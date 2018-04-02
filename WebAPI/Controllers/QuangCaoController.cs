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
    public class QuangCaoController : ApiController
    {
        private NewsWebsite db = new NewsWebsite();

        [HttpGet]
        public IHttpActionResult getAds_Random()
        {
            var result = db.QuangCaos.OrderBy(r => Guid.NewGuid()).ToList();
            if(result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getAds_All()
        {
            var result = db.QuangCaos.ToList();
            if (result != null && result.Any())
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getAdsByID(int id)
        {
            var result = db.QuangCaos.Find(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpPost]
        public int InsertAds(JObject ads)
        {
            try
            {
                QuangCao data = new QuangCao();
                data.MoTa = ads["descrip"].ToString();
                data.Url = ads["link"].ToString();
                data.urlHinh = ads["image"].ToString();
                data.vitri = (int)ads["position"];
                db.QuangCaos.Add(data);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int UpdateAds(JObject ads)
        {
            try
            {
                var data = db.QuangCaos.Find(ads["adsid"]);
                data.MoTa = ads["descrip"].ToString();
                data.Url = ads["link"].ToString();
                data.urlHinh = ads["image"].ToString();
                data.vitri = (int)ads["position"];
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int DeleteAds(int id)
        {
            try
            {
                var ads = db.QuangCaos.Find(id);
                db.QuangCaos.Remove(ads);
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
