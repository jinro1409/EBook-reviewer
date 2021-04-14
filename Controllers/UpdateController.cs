using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Update
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                account a = (account)Session["user"];
                string username = a.username;
                DateTime dob = DateTime.Parse(Request["dob"]);
                String email = Request["mail"];
                String name = Request["fullname"];
                bool gender = Request["gender"].Equals("male");
                accountDAO ab = new accountDAO();
                ab.UpdateProfile(username, name, email, dob, gender);
                a.fullname = name;
                a.dob = dob;
                a.email = email;
                a.gender = gender;
                Session["user"] = a;
                Session["noti"] = "Update Profile Sucessfull";
               
                return RedirectToAction("Index", "ProfileView");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}