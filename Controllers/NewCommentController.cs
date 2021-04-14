using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NewCommentController : Controller
    {
        // GET: NewComment
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                account a = (account)Session["user"];
                int Id = int.Parse(Request["bookid"]);
                String cmt = Request["comment"];
                commentDAO e = new commentDAO();
                e.addnewComment(a.username, cmt, Id);
                string w = "Detail?bookid=" + Id;
                Session["id"]=Id;
                return RedirectToAction("Index","Detail");
               
            }
            else
            {
                Session["notify"] = "You have not yet login";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}