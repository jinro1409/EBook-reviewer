using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;

namespace WebApplication1.Controllers

{
    public class FogotController : Controller
    {
        // GET: Fogot
        public ActionResult Index()
        {
            ViewData["forgotMess"] = Session["fogot"];
            return View();
        }
        [HttpPost]
        public ActionResult IndexPost()
        {
            string code = Request["email"];
          
             account a=new accountDAO().getaccbyEmail(code);
            if (a == null)
            {
                Session["fogot"] = "Email is not yet Register";
                return RedirectToAction("Index", "Fogot");
            }
            else
            {
                SendMail SendMailDAO = new SendMail();
                string subject = "Thông tin tài khoản";
                string content = "Cảm ơn bạn đã đăng ký sử dụng dịch vụ ! Tài khoản của bạn là: " + a.username+"Mật khẩu:"+a.password;
                SendMailDAO.Send(a.email, subject, content);
                return RedirectToAction("Index", "Login");
            }
           
            

        }
    }
}