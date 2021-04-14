using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;

namespace WebApplication1.Controllers
{
    public class UpPointController : Controller
    {
        // GET: UpPoint
        public ActionResult Index()
        {
            int book = Int32.Parse(Request["bookid"]);
            int upPoint = Int32.Parse(Request["uppoint"]);
            if (new BookDAO().upPoint(book, upPoint) != 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}