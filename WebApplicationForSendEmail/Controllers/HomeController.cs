using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplicationForSendEmail.Models;

namespace WebApplicationForSendEmail.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmailViewModel emailObj)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    string fEmail = ConfigurationManager.AppSettings["fEmail"].ToString();
                    string fEmailPwd = ConfigurationManager.AppSettings["fEmailPwd"].ToString();

                    MailMessage ms = new MailMessage(fEmail, emailObj.ToEmailId);
                    ms.Subject = emailObj.Subject;
                    ms.Body = emailObj.BodyText;
                    ms.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.Credentials = new System.Net.NetworkCredential() { UserName = fEmail, Password = fEmailPwd };
                    client.EnableSsl = true;
                    client.Send(ms);

                    ViewBag.message = "Email sent successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.message = "Email sent failed";
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}