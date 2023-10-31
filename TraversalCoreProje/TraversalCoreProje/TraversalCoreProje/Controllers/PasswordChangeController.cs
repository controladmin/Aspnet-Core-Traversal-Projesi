using AutoMapper.Internal; //MapRequest kullanabilmek için ekledik
using EntityLayer.Concreate; // AppUser kullanabilmek için ekledik
using MailKit.Net.Smtp; // SmtpClient kullanabilmek için ekledik
using Microsoft.AspNetCore.Authorization; //  [AllowAnonymous] kullanmak için ekledik
using Microsoft.AspNetCore.Identity; // UserMenager sınıfını kullanabilmek için ekledik
using Microsoft.AspNetCore.Mvc;
using MimeKit; // MimeMessage sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models; // ForgetPasswordViewModel sınıfını kullanabilmek için ekledik

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userMenager;

        public PasswordChangeController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user =await _userMenager.FindByEmailAsync(model.Mail);
            string passwordResetToken =await _userMenager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userID = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);


            /* gönderen bilgileri*/
            MimeMessage msg = new MimeMessage();
            /* Admin yerine mailRequest.Name gelecek mail gönderen ismi mail adresi yerined mailRequest.SenderMail gelecek*/
            MailboxAddress mail = new MailboxAddress("Traversal", "gönderici mail adresi");
            msg.From.Add(mail);

            /* Alıcı bilgileri*/
            MailboxAddress mailTo = new MailboxAddress("User", model.Mail);
            msg.To.Add(mailTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            msg.Body = bodyBuilder.ToMessageBody(); /* Body kısmını gönderiyor mail olarak*/

            // msg.Body = mailRequest.Body;
            msg.Subject ="Şifre Değişiklik Talebi";
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            /* traversalcore2@gmail.com şifre:123456aA- çifr doğrulama:fhvevuwmjwlkpnzm */
            /* gönderici mail adresi çift doğrulama yapmalı*/
            client.Authenticate("gönderici mail adresi", "iki adımlı doğrulama şifresi");
            client.Send(msg);
            client.Disconnect(true);

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid,string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var userid=TempData["userid"];
            var token= TempData["token"];
            if (userid == null || token == null)
            {
                // hata mesajı
            }
            
            
                var user = await _userMenager.FindByIdAsync(userid.ToString());
                var result = await _userMenager.ResetPasswordAsync(user, token.ToString(), model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    return View();
                }
            
             
        }
    }
}
