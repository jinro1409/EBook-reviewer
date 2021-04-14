using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.dal;
using System.Dynamic;

namespace WebApplication1.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index()
        {
            string id_raw = Request.QueryString["bookid"];
            if (id_raw == null)
            {
                id_raw = Session["id"].ToString();
            }
            int id = Int32.Parse(id_raw);
            


            commentDAO cbd = new commentDAO();
            List<comment> comments = cbd.getbyBook(id);
            List<author> authors = new AuthorDAO().getAuthorByBookID(id);
            categoryDAO cd = new categoryDAO();
            BookDAO db = new BookDAO();
            int count = comments.Count;
            dynamic dy = new ExpandoObject();
            dy.book = db.getOne(id);
            ViewData["count"] = count;
            dy.cates = cd.getAll();
            dy.comments = comments;
            dy.replys= cbd.getReplys(id);
            dy.authors = authors;
            Session.Remove("id");
            return View(dy);
        }
    }
}