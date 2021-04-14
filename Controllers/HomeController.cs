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
    public class HomeController : Controller
    {
        BookDAO bd = new BookDAO();
        categoryDAO cd = new categoryDAO();

        // GET: Home
        public ActionResult Index()
        {
            int pageIndex = 1;
            // If user clicked on other page index
            if (Request.QueryString["pageIndex"] != null)
            {
                // Then pageIndex = value of that page index user clicked
                pageIndex = Int32.Parse(Request.QueryString["pageIndex"]);
            }
            int pageSize = 5;

          

            // Count all homes in database (Table Home)
            int totalPage = bd.countPage(pageSize);
            // IF count % pageSize == 0 => totalPage = count / pageSize
            

            // Display total of page to Home page for pagging
            ViewData["totalPage"] = totalPage;
            // Display pageIndex to active page current
            ViewData["pageIndex"] = pageIndex;

            // Display list of homes and list of places to Home page
            dynamic dy = new ExpandoObject(); // dynamic - multiple model
            dy.cates = cd.getAll();
            dy.books =bd.getAll(pageSize, pageIndex);

            return View(dy);

            
        }
    }
}