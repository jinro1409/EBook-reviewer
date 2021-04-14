using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class comment
    {
        public int id { get; set; }
        public account createdby { get; set; }
        public string detail { get; set; }
        public int bookid { get; set; }
        public DateTime createdon { get; set; }

        public comment()
        {
        }

        public comment(int id, account createdby, string detail, int bookid, DateTime createdon)
        {
            this.id = id;
            this.createdby = createdby;
            this.detail = detail;
            this.bookid = bookid;
            this.createdon = createdon;
        }
    }
}