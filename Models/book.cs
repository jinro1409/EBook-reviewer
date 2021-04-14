using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class book
    {
        public int id { get; set; }
        public string shortDes { get; set; }
        public string name { get; set; }
        public string des { get; set; }
        public account createdby { get; set; }
        public string language { get; set; }
        public string img { get; set; }
        public DateTime pulishedDate { get; set; }
        public int upPoint { get; set; }
        public int downPoint { get; set; }
        public book()
        {
        }

        public book(int id, string shortDes, string name, string des, account createdby, string language, string img, DateTime pulishedDate, int upPoint, int downPoint)
        {
            this.id = id;
            this.shortDes = shortDes;
            this.name = name;
            this.des = des;
            this.createdby = createdby;
            this.language = language;
            this.img = img;
            this.pulishedDate = pulishedDate;
            this.upPoint = upPoint;
            this.downPoint = downPoint;
        }

        public override string ToString()
        {
            return id + "\t" + name + "\t" + shortDes + "\t" + des + "\t" + createdby + "\t" + language + "\t" + img + "\t" + pulishedDate;
        }
    }
}