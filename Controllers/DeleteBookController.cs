using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DeleteBookController : Controller
    {
        // GET: DeleteBook
        public ActionResult Index()
        {
            account a = (account)Session["user"];
            if (a != null)
            {
                if (a.Role)
                {
                    Console.WriteLine("chao");
                    string bid = Request["bid"];
                    BookDAO db = new BookDAO();
                    db.delete(Int32.Parse(bid));
                    return RedirectToAction("Index", "Manage");
                }
            }
            return RedirectToAction("Index", "Login");
        }
    }
}