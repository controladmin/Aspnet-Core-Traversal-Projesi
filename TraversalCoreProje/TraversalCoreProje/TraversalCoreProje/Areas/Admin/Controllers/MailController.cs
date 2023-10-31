using MailKit.Net.Smtp; // SmtpClient sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using MimeKit; // MailBoxAdress sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models; // MailRequest sınıfını kulanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Mail")]
    public class MailController : Controller
    {
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Index")]
        [HttpPost]
        /* Model klasörü altına MailRequest diye bir class tanımladık mail propertyleri içinde tutuyor*/
        public IActionResult Index(MailRequest mailRequest)
        {
            /* gönderen bilgileri*/
            MimeMessage msg = new MimeMessage();
            /* Admin yerine mailRequest.Name gelecek mail gönderen ismi mail adresi yerined mailRequest.SenderMail gelecek*/
            MailboxAddress mail = new MailboxAddress(mailRequest.Name, mailRequest.SenderMail); 
            msg.From.Add(mail);

            /* Alıcı bilgileri*/
            MailboxAddress mailTo = new MailboxAddress("User",mailRequest.ReceiverMail);
            msg.To.Add(mailTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            msg.Body = bodyBuilder.ToMessageBody();

           // msg.Body = mailRequest.Body;
            msg.Subject = mailRequest.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            /* traversalcore2@gmail.com şifre:123456aA- çifr doğrulama:fhvevuwmjwlkpnzm */
            /* gönderici mail adresi çift doğrulama yapmalı*/
            client.Authenticate(mailRequest.SenderMail, mailRequest.Password);  
            client.Send(msg);
            client.Disconnect(true);
            return View();
           
        }
    }
}
