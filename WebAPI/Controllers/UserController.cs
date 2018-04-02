using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private NewsWebsite db = new NewsWebsite();

        [HttpPost]
        public IHttpActionResult Login(JObject objects)
        {
            string username = objects["username"].ToString();
            string password = objects["password"].ToString();
            var user = db.Users.Where(x => x.Username == username && x.Password == TienIchController.Base64Encode(password)).SingleOrDefault();
            if(user != null)
            {
                UserLogin data = new UserLogin(user.Username, user.idUser, 1, user.idGroup);
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getUserAll()
        {
            var listUser = db.Users.ToList();
            if (listUser != null && listUser.Any())
                return Ok(listUser);
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult getUserByID(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                user.Password = TienIchController.Base64Decode(user.Password);
                return Ok(user);
            } 
            return NotFound();
        }

        [HttpGet]
        public int CheckUserExist(string username)
        {
            var user = db.Users.Where(x => x.Username == username);
            if(user != null && user.Any())
                return 1;
            return 0;
        }

        [HttpPost]
        public int InsertUser(JObject user)
        {
            try
            {
                User data = new User();
                data.HoTen = user["name"].ToString();
                data.Username = user["username"].ToString();
                data.Password = TienIchController.Base64Encode(user["password"].ToString());
                data.DiaChi = user["address"].ToString();
                data.Dienthoai = user["phone"].ToString();
                data.Email = user["email"].ToString();
                data.NgayDangKy = DateTime.ParseExact(DateTime.Now.ToShortDateString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                data.NgaySinh = DateTime.ParseExact(user["birthday"].ToString(),"yyyy-MM-dd", CultureInfo.InvariantCulture);
                data.idGroup = (int)user["group"];
                data.GioiTinh = (byte)user["sex"];
                data.Active = (int)user["active"];
                db.Users.Add(data);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int UpdateUser(JObject user)
        {
            try
            {
                var data = db.Users.Find(user["userid"]);
                data.HoTen = user["name"].ToString();       
                data.DiaChi = user["address"].ToString();
                data.Dienthoai = user["phone"].ToString();
                data.Email = user["email"].ToString();
                data.NgaySinh = DateTime.ParseExact(user["birthday"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                data.idGroup = (int)user["group"];
                data.GioiTinh = (byte)user["sex"];
                data.Active = (int)user["active"];
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [HttpPost]
        public int DeleteUser(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
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
