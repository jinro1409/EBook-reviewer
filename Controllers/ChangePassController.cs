using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.dal;

namespace WebApplication1.Controllers
{
    public class ChangePassController : Controller
    {
        // GET: ChangePass
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                account a = (account)Session["user"];
                string username = a.username;
                string old = Request["oldpass"];
                string new1 = Request["newpass"];
                string re = Request["renewpass"];
                if (!old.Equals(a.password))
                {
                    Session["noti"] = "Wrong old password";
                    return RedirectToAction("Index", "ProfileView");
                }

                else if (!new1.Equals(re))
                {
                    Session["noti"] = "Re-password is not match";
                    return RedirectToAction("Index", "ProfileView");
                }
                else
                {
                    Session["noti"] = "Change password successfully";
                    new accountDAO().Updatepassword(a.username, new1);

                    return RedirectToAction("Index", "ProfileView");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
    }
