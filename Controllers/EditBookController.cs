using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EditBookController : Controller
    {
        // GET: EditBook
        public ActionResult Index()
        {
            account a = (account)Session["user"];
            if (a != null)
            {
                if (a.Role)
                {

                    int bid = Int32.Parse(Request["bid"]);
                    AuthorDAO authorDAO = new AuthorDAO();
                    categoryDAO cdb = new categoryDAO();
                    book b = new BookDAO().getOne(bid);
                    List<author> authors = authorDAO.getAll();
                    List<category> categories = cdb.getAll();
                    List<book_categories> bcats = cdb.getAllss();
                    dynamic dy = new ExpandoObject(); // dynamic - multiple model
                    dy.book = b;
                    dy.cates = categories;
                    dy.bcats = bcats;
                    dy.authors = authors;
                    dy.author = authorDAO.getAuthorByBookID(bid);
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
        [HttpPost]
        public ActionResult IndexPost(HttpPostedFileBase img)
        {
            //get id of current book
            int bid = Int32.Parse(Request["bid"]);
            string[] category_ids = Request["category"].Split(',');
            string title = Request["title"];
            //string img = Request["img"];
            string languge = Request["language"];
            string des = Request["description"];
            account a = (account)Session["user"];
            BookDAO bd = new BookDAO(); ;
            book b = bd.getOne(bid);
            b.name = title;
            b.img = "img";
            b.language = languge;
            b.des = des;
            bd.updateBook(b);
            //remove all old categories
            categoryDAO cd = new categoryDAO();
            cd.removeCateOfBook(bid);
            //add categories
            for (int i = 0; i < category_ids.Length - 1; i++)
            {
                int cid = Int32.Parse(category_ids[i]);
                bd.addCforlast(cid, bid);
            }
            AuthorDAO authorDAO = new AuthorDAO();
            //check if book's author is already existed 
            if (Request["isNewAuthor"] == null)
            {
                //add a connection between book and author
                int aid = Int32.Parse(Request["authorid"]);
                authorDAO.AddAuthorForBook(aid, bid);
            }
            else
            {
                //create new author
                string author_name = Request["author_name"];
                string lifestory = Request["lifestory"];
                string nation = Request["nation"];
                string dob = DateTime.Parse(Request["dob"]).ToString("yyyy-MM-dd");
                authorDAO.AddAuthor(author_name, lifestory, nation, dob);
                //add a connection between book and new author
                authorDAO.AddAuthorForBook(authorDAO.getLastId(), bid);
            }
            if (img.ContentLength > 0)
            {
                var extenstion = Path.GetExtension(img.FileName);
                string fileName = "i" + bid + extenstion;
                string savedFileName = Server.MapPath("~/assets/img/book/" + fileName);
                img.SaveAs(savedFileName);
                bd.updateBook(new book(bid, des, title, des, a, languge, fileName, DateTime.Now,0,0));
            }
            return RedirectToAction("Index", "Manage");

        }
    }
}