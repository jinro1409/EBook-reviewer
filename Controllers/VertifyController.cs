using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;

namespace WebApplication1.Controllers
{
    public class VertifyController : Controller
    {
        // GET: Verify
        public ActionResult Index()
        {
            ViewData["vertifyMess"] = Session["vertifyNotify"];
            return View();
        }
        [HttpPost]
        public ActionResult IndexPost()
        {
            string code = Request["code"];
            if (code.Equals(Session["code_verify"].ToString()))
            {
                var uss = Session["username"];
                new accountDAO().UpdateVertify(uss.ToString());
                Session.Remove("username");
                Session.Remove("code");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Session["vertifyNotify"] = "Wrong Code";
                return RedirectToAction("Index", "Vertify");
            }

        }
    }
}