using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.dal;
using System.Dynamic;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {

       
        // GET: Categories
        public ActionResult Index()
        {
          
            BookDAO bd = new BookDAO();
            categoryDAO cd = new categoryDAO();
            int cateid = Int32.Parse(Request.QueryString["cateid"]);
            int pageIndex = 1;
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = Int32.Parse(Request.QueryString["pageIndex"]);
            }
            int pageSize = 2;



            // Count all homes in database (Table Home)
            int total = bd.getbycid(cateid, 1,1000).Count;
            // IF count % pageSize == 0 => totalPage = count / pageSize
            int totalPage = total/pageSize;
            if (total % pageSize != 0)
            {
                totalPage += 1;
            }

            // Display total of page to Home page for pagging
              ViewData["totalPage"] = totalPage;
            // Display pageIndex to active page current
             ViewData["pageIndex"] = pageIndex;
            ViewData["cateid"] = cateid;
            string txt = " ";
            ViewData["text"] = txt;
            // Display list of homes and list of places to Home page
            dynamic dy = new ExpandoObject(); // dynamic - multiple model
            dy.cates = cd.getAll();
            dy.books = bd.getbycid(cateid,pageIndex,pageSize);

            
            return View(dy);
        }
    }
}