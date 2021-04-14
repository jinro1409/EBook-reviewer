using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;

namespace WebApplication1.Controllers
{
    public class DownPointController : Controller
    {
        // GET: DownPoint
        public ActionResult Index()
        {
            int book = Int32.Parse(Request["bookid"]);
            int downPoint = Int32.Parse(Request["downpoint"]);
            if (new BookDAO().downPoint(book, downPoint) != 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}