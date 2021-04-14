using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class author
    {
        public int id { get; set; }
        public string  name { get; set; }
        public string lifeStory { get; set; }
        public string national { get; set; }
        public DateTime dob { get; set; }

        public author(int id, string name, string lifeStory, string national, DateTime dob)
        {
            this.id = id;
            this.name = name;
            this.lifeStory = lifeStory;
            this.national = national;
            this.dob = dob;
        }

        public author()
        {
        }

        public override string ToString()
        {
            return id +"\t"+name + "\t" + lifeStory + "\t" + national + "\t" + dob;
        }
    }
}