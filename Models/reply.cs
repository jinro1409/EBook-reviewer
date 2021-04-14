using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class reply
    {
        public int id { get; set; }
        public int cmtid { get; set; }
        public string detail { get; set; }
        public string username { get; set; }

        public reply()
        {
        }

        public reply(int id, int cmtid, string detail, string username)
        {
            this.id = id;
            this.cmtid = cmtid;
            this.detail = detail;
            this.username = username;
        }
    }
}