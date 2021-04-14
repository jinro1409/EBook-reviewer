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
    public class ManageController : Controller
    {
        // GET: Manage
        public ActionResult Index()
        {
            account a = (account)Session["user"];
            if (a != null)
            {
                if (a.Role)
                {
                    BookDAO db = new BookDAO();
                    accountDAO adb = new accountDAO();
                    categoryDAO cdb = new categoryDAO();
                    commentDAO cd = new commentDAO();
                    AuthorDAO authorDAO = new AuthorDAO();
                    List<author> authors = authorDAO.getAll();
                    List<book> books = db.getAll(1000, 1);
                    List<comment> comments = cd.getAll();
                    List<account> accounts = adb.getAll();
                    List<category> categories = cdb.getAll();
                    List<book_categories> bcats = cdb.getAllss();
                    dynamic dy = new ExpandoObject(); // dynamic - multiple model
                    dy.books = books;
                    dy.cates = categories;
                    dy.bcats = bcats;
                    dy.comments =comments;
                    dy.accounts = accounts;
                    dy.authors = authors;
                    ViewData["countb"] = db.getAll(1000, 1).Count;
                    ViewData["counta"] = accounts.Count;
                    ViewData["countc"] = comments.Count;
                    return View(dy);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
    }
