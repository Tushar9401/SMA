
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SMA.WebUI.EmailToUser
{
    public class ForgotPasswordEmail
    {

        public static void ForgotPasswordEmailToUser(string emailId, string activationCode, string OTP)
        {
            var GenerateUserVerificationLink = "/UserLogin/ChangePassword/" + activationCode;
            var link = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, GenerateUserVerificationLink);

            var fromMail = new MailAddress("tushithakkar1221@gmail.com", "Tushar");
            var fromEmailPassword = "gnouagwlrpyqtkwr";
            var toEmail = new MailAddress(emailId);

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailPassword);

            var Message = new MailMessage(fromMail, toEmail);

            Message.Subject = "Password Reset";
            Message.Body = "<br/> Please Click on the below link for password change" +
                         "<br/><br/><a href=" + link + ">" + link + "</a>" +
                         "<br/> OTP for password change :" + OTP;
            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }
    }
}

