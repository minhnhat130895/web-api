using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ViewModelTin
    {
        public ViewModelTin(List<Tin> list, Tin nextPost, Tin prevPost)
        {
            listTin = list;
            this.nextPost = nextPost;
            this.prevPost = prevPost;
        }
        public List<Tin> listTin { get; set; }
        public Tin nextPost { get; set; }
        public Tin prevPost { get; set; }
    }
}