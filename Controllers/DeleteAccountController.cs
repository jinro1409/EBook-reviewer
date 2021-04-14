using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.dal;

namespace WebApplication1.Controllers
{
    public class DeleteAccountController : Controller
    {
        // GET: DeleteAccount
        public ActionResult Index()
        {
            String id = Request["aid"];
            accountDAO ad = new accountDAO();
           
                    
            string email = new accountDAO().getaccbyUser(id).email;
            SendMail sendMailDao = new SendMail();
            string subject = "Tài khoản của bạn đã bị xóa!";
            string content = "Cảm ơn bạn đã đăng ký sử dụng dịch vụ!";
            sendMailDao.Send(email, subject, content);
            ad.delete(id);
            return RedirectToAction("Index", "Manage");
        }
    }
}