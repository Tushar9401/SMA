using SMA.Core.Contracts;
using SMA.Core.Models;
using SMA.SQl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SMA.WebUI.Controllers
{
    public class UserRegistrationController : Controller
    {
        IRepository<UserRegistration> context;

        #region entity connection
        AppDbContext objCon = new AppDbContext();
        #endregion
        public UserRegistrationController(IRepository<UserRegistration> userRegistration)
        {
            context = userRegistration;
        }

        // GET: UserRegistration
        public ActionResult Index()
        {
            return View();
        }
        public bool IsEmailExists(string eMail)
        {
            var IsCheck = objCon.User.Where(email => email.Email == eMail).FirstOrDefault();
            return IsCheck !=null;
        }

        [HttpPost]
        public ActionResult Index(UserRegistration objUsr)
        {
            // email not verified on registration time
            objUsr.EmailVerfication = false;
            var isExists=IsEmailExists(objUsr.Email);
            if (isExists)
            {
                ModelState.AddModelError("", "Email Already Exists");
            }
            else
            {
                //it generate unique code       
                objUsr.ActivationCode = Guid.NewGuid().ToString();
                //password convert    
                objUsr.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(objUsr.Password)));
                objUsr.ConfirmPassword = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(objUsr.ConfirmPassword)));
                context.Insert(objUsr);
                context.Commit();

                #region Send Verification Mail
                SendEmailToUser.SendEmail(objUsr.Email, objUsr.ActivationCode.ToString());
                var Message = "Registration Completed.Please Check You email :" + objUsr.Email;
                ViewBag.Message = Message;
                #endregion
                return View("Registration");
            }
            return View();
        }

        public ActionResult UserVerification(string id)
        {
            bool Status = false;

            objCon.Configuration.ValidateOnSaveEnabled = false; // Ignor to password confirmation     
            var IsVerify = objCon.User.Where(u => u.ActivationCode == new Guid(id).ToString()).FirstOrDefault();

            if (IsVerify != null)
            {
                IsVerify.EmailVerfication = true;
                objCon.SaveChanges();
                ViewBag.Message = "Email Verification completed";
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request...Email not verify";
                ViewBag.Status = false;
            }

            return View("UserVerification");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "UserLogin");
        }
    }
}