using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class ReplyController : Controller
    {
        // GET: Reply
        public ActionResult Index()
        {
            account a = (account)Session["user"];
            int Id = int.Parse(Request["cmtid"]);
            int bId = int.Parse(Request["bookid"]);
            String cmt = Request["detail"];
            commentDAO e = new commentDAO();
            e.addReply(a.username, cmt, Id);
            string w = "Detail?bookid=" + bId;
            Session["id"] = bId;
            return RedirectToAction("Index", "Detail");
        }
    }
}