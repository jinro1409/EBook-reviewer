using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class DeletecmtController : Controller
    {
        // GET: Deletecmt
        public ActionResult Index()
        {
            int Id = int.Parse(Request["cmtid"]);

            commentDAO e = new commentDAO();
            e.deletebyUser(Id); ;
            int Idm =int.Parse(Request["bookid"]);
            Session["id"] = Idm;
            return RedirectToAction("Index", "Detail");
        }
    }
}