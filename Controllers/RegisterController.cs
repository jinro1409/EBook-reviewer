using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            ViewData["notify"] = Session["notify"];
            Session.Remove("notify");
            return View();
           
        }
        [HttpPost]
        public ActionResult IndexPost()
        {
            string username = Request["username"];
            string password = Request["password"];
            string a = Request["dob"];
            DateTime dob = DateTime.Parse(a);
            string email = Request["email"];
            string name = Request["fullname"];
            bool gender = Request["gender"].Equals("male");
            string rePassword = Request["repassword"];
            accountDAO r = new accountDAO();
            Regex regexPW = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\!\#\@\$\%\^\&\/\(\)\=\?\*\-\+\-\\_\.\:\;\,\]\[\{\}])[a-zA-Z\d\!\#\@\$\%\^\&\/\(\)\=\?\*\-\+\-\\_\.\:\;\,\]\[\{\}]{8,}$");
            if (!regexPW.IsMatch(password))
            {
                Session["notify"] = "Password must contain at least a letter, upper case letter, a number, a special character and at least 8 characters!";
                return RedirectToAction("Index", "Register");
            }
            if (r.getaccbyUser(username) != null|| r.getaccbyEmail(email) != null)
            {
                Session["notify"] = "Account already register!";
                return RedirectToAction("Index", "Register");
            }
            else
            {
                
                    r.addAccount(username, password, name, dob, email, gender);
                    Session["notify"] = "Successfully registration";
                    SendMail sendMailDao = new SendMail();
                    string code_verify = sendMailDao.randomCode(6);
                    Session["code_verify"] = code_verify;
                    Session["username"] = username;
                    string subject = "Xác thực địa chỉ email!";
                    string content = "Cảm ơn bạn đã đăng ký sử dụng dịch vụ! Mã xác thực của bạn là: " + code_verify;
                    sendMailDao.Send(email, subject, content);
                    return RedirectToAction("Index", "Vertify");
                
               
            }
        }
        }
}