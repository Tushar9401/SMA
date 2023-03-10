
using SMA.Core.Models;
using SMA.SQl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using SMA.Core.Contracts;
using SMA.SQl.Migrations;

namespace SMA.WebUI.Controllers
{
    public class UserLoginController : Controller
    {
        #region entity connection
        AppDbContext objCon = new AppDbContext();
        #endregion
        // GET: UserLogin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin LgnUsr)
        {
            var _passWord = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(LgnUsr.Password)));
            bool Isvalid = objCon.User.Any(x => x.Email == LgnUsr.EmailId &&
            x.Password == _passWord);
            if (Isvalid)
            {
                int timeout = LgnUsr.Rememberme ? 60 : 5; // Timeout in minutes, 60 = 1 hour.    
                var ticket = new FormsAuthenticationTicket(LgnUsr.EmailId, false, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = System.DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Information... Please try again!");
            }
            return View();
        }

        public bool IsEmailExists(string eMail)
        {
            var IsCheck = objCon.User.Where(email => email.Email == eMail).FirstOrDefault();
            return IsCheck != null;
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ForgotPassword(ForgotPassword pass)
        {
            var IsExists = IsEmailExists(pass.EmailId);

            if (!IsExists)
            {
                ModelState.AddModelError("", "This email is not exists");

            }
            else
            {
                var objUsr = objCon.User.Where(x => x.Email == pass.EmailId).FirstOrDefault();

                // Genrate OTP     
                string OTP = GeneratePassword();

                objUsr.ActivationCode = Guid.NewGuid().ToString();
                objUsr.OTP = OTP;
                objCon.Entry(objUsr).State = System.Data.Entity.EntityState.Modified;
                objCon.SaveChanges();

                EmailToUser.ForgotPasswordEmail.ForgotPasswordEmailToUser(objUsr.Email, objUsr.ActivationCode.ToString(), objUsr.OTP);
                return View();
            }
            return View();
        }
        public string GeneratePassword()
        {
            string OTPLength = "4";
            string OTP = string.Empty;

            string Chars = string.Empty;
            Chars = "1,2,3,4,5,6,7,8,9,0";

            char[] splitChar = { ',' };
            string[] arr = Chars.Split(splitChar);

            string NewOTP = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(OTPLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                NewOTP += temp;
                OTP = NewOTP;
            }
            return OTP;
        
         }

        public ActionResult ChangePassword()
        {
            return View();
        }

      
        
     }
}

           
       
 

     