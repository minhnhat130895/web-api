using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserLogin
    {
        public string username { get; set; }
        public int id { get; set; }
        public int result { get; set; }
        public int auth { get; set; }

        public UserLogin(string username, int id, int result, int auth)
        {
            this.username = username;
            this.id = id;
            this.result = result;
            this.auth = auth;
        }

    }
}