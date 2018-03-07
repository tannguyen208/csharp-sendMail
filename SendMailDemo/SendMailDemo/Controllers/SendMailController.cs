using SendMailDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SendMailDemo.Controllers
{
    public class SendMailController : Controller
    {
        // GET: SendMail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(SimpleMail data)
        {
            if (ModelState.IsValid)
            {
                //Create MailMessage
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("myaptechmail@gmail.com");
                mail.To.Add(data.To);
                mail.Subject = data.Subject;
                mail.Body = data.Body;

                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;

                //Create SMTP for send mail
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("myaptechmail", "thanhbinh");
                smtp.EnableSsl = true;

                //Call Send mail -> Check all Spam
                smtp.Send(mail);

                return RedirectToAction("Success");
            }

            return View(data);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
