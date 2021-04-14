using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class category
    {
        public int id { get; set; }
        public string cate { get; set; }

        public category(int id, string cate)
        {
            this.id = id;
            this.cate = cate;
        }

        public category()
        {
        }

        public override string ToString()
        {
            return id+"\t"+cate;
        }
    }
}