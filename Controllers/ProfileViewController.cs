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
    public class ProfileViewController : Controller
    {
        // GET: ProfileView
        public ActionResult Index()
        {
            account a =(account) Session["user"];
            dynamic dy = new ExpandoObject();
            dy.acc = a;
            categoryDAO cd = new categoryDAO();
            dy.cates = cd.getAll();
            commentDAO cbd = new commentDAO();
            List<comment> co = cbd.getbyUser(a.username);
            int countcmt = co.Count;
            ViewData["countcmt"] = countcmt;
            ViewBag.notifi = Session["noti"];
            Session.Remove("noti");
            return View(dy);

        }
    }
}