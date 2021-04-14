using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            Session.Remove("user");
            Session.Remove("userName");
            return RedirectToAction("Index", "Login");
           
        }
    }
}