using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            BookDAO bd = new BookDAO();
            categoryDAO cd = new categoryDAO();
            string txt = Request["text"];
            int pageIndex = 1;
            if (Request.QueryString["pageIndex"] != null)
            {
                pageIndex = Int32.Parse(Request.QueryString["pageIndex"]);
            }
            int pageSize = 2;
            // Count all homes in database (Table Home)
            int total = bd.getbyname(txt, 1, 1000).Count;
            // IF count % pageSize == 0 => totalPage = count / pageSize
            int totalPage = total / pageSize;
            if (total % pageSize != 0)
            {
                totalPage += 1;
            }

            // Display total of page to Home page for pagging
            ViewData["totalPage"] = totalPage;
            // Display pageIndex to active page current
            ViewData["pageIndex"] = pageIndex;
            ViewData["text"] = txt;
            dynamic dy = new ExpandoObject(); // dynamic - multiple model
            dy.cates = cd.getAll();
            dy.books = bd.getbyname(txt, pageIndex, pageSize);

            return View(dy);
        }
    }
}