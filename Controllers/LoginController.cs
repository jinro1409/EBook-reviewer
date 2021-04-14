using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            string userName = "";
            string password = "";
            bool rememberCk = false;
            // get cookie of email and password from Cookies has name = "email" an "password" 
            HttpCookie c_userName = HttpContext.Request.Cookies.Get("userName");
            HttpCookie c_password = HttpContext.Request.Cookies.Get("password");
            // if cookies of email and password has value
            if (c_userName != null && c_password != null)
            {
                // email and password get value from cookie
                userName = c_userName.Value;
                password = c_password.Value;
                ViewBag.userName = userName;
                ViewBag.password = password;
                rememberCk = true;
            }
            ViewBag.rememberCk = rememberCk;
            ViewData["notify"] = Session["notify"];
            Session.Remove("notify");
            return View();
            
        }

        [HttpPost]
        public ActionResult IndexPost(string remember)
        {
            string mess = "", userName = "", password = "";
            userName = Request["username"];
            password = Request["password"];
            //remember = Request["remember"];
            if (new accountDAO().getAccount(userName, password) != null)
            {
                HttpCookie c_userName = new HttpCookie("userName", userName);
                HttpCookie c_password = new HttpCookie("password", password);
                if (remember.Equals("true")) // if user click checkbox lưu tài khoản
                {
                    //    // Save account of user to cookies

                    //    // Set time out for cookie
                    c_userName.Expires = DateTime.Now.AddDays(1);
                    c_password.Expires = DateTime.Now.AddDays(1);
                    //    // Add to cookie
                    Response.Cookies.Add(c_userName);
                    Response.Cookies.Add(c_password);
                }
                else
                {
                    //if (Request.Cookies["c_userName"] != null)
                    //{
                    HttpCookie c_user = new HttpCookie("userName");
                    c_user.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(c_user);
                    //}
                    //if (Request.Cookies["c_password"] != null)
                    //{
                    HttpCookie c_pass = new HttpCookie("password");
                    c_pass.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(c_pass);
                    //}
                    //Request.Cookies.Clear();
                }
                account a = new accountDAO().getAccount(userName, password);
                Session["user"] = a;
                Session["userName"] = a.Fullname;
                if (a.Status)
                {
                    if (a.role)
                    {


                        return RedirectToAction("Index", "Manage");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else

                {
                    SendMail sendMailDao = new SendMail();
                    Session["username"] = userName;
                    account b = new accountDAO().getaccbyUser(userName);
                    string code_verify = sendMailDao.randomCode(6);
                    Session["code_verify"] = code_verify;
                    string subject = "Xác thực địa chỉ email!";
                    string content = "Cảm ơn bạn đã đăng ký sử dụng dịch vụ của Luxstay! Mã xác thực của bạn là: " + code_verify;
                    sendMailDao.Send(b.email, subject, content);
                    return RedirectToAction("Index", "Vertify");
                }

            }
            else
            {

                mess = "User name or password is incorect!";
                Session["notify"] = mess;
                return RedirectToAction("Index", "Login");
            }
            //ViewBag.loginMess = mess;
        }
    }
}