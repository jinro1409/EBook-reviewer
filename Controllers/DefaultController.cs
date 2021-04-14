using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;


namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            String id = Request["acid"];
            commentDAO ad = new commentDAO();
            SendMail sendMailDao = new SendMail();
            ad.delete(int.Parse(id));
           
            return RedirectToAction("Index", "Manage");
        }
    }
}