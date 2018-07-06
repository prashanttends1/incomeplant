using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System.Threading;
using mlmStudio.Utility;


namespace mlmStudio.Controllers
{
    public class AccountController : Controller
    {
        //
        SIContext db = new SIContext();
        // GET: /Account/
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(System.Web.Mvc.FormCollection frmCollection)
        {
            string email = frmCollection["email"].ToString();
            string password = frmCollection["password"].ToString();
            var login = db.Users.FirstOrDefault(i => i.Username == email && i.Password == password);
            if (login != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, login.Username.ToString())); // store username of user
                claims.Add(new Claim(ClaimTypes.Role, login.RoleUser_UserIds.FirstOrDefault().RoleId.ToString()));
                claims.Add(new Claim(ClaimTypes.Sid, login.Id.ToString())); // store id of user

                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var authenticationManager = Request.GetOwinContext().Authentication;
                authenticationManager.SignIn(identity);

                var claimsPrincipal = new ClaimsPrincipal(identity);
                Thread.CurrentPrincipal = claimsPrincipal;

                return Redirect("~/Home/Index");
            }
            else
            {
                ViewBag.Msg = "!Invalid UserName and Password";
            }
            return View();
        }

        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(System.Web.Mvc.FormCollection frmCollection)
        {
            User user = new User();
            user.Username = frmCollection["name"];
            user.Password = frmCollection["password2"];
            user.Email= frmCollection["email"];
            var parent= frmCollection["parent"];
            var sponser= frmCollection["sponser"]; 
            if(db.Users.Where(u=>u.Username==user.Username).SingleOrDefault()!=null)
            {
                ViewBag.Msg = "Username already taken.";
                return View();
            }
            
            User userparent = db.Users.Where(u => u.Username == parent).SingleOrDefault();
            User usersponser = db.Users.Where(u => u.Username == sponser ).SingleOrDefault();
            if (userparent==null || usersponser==null)
            {
                ViewBag.Msg = "Parent or Sponser doesn't exist";
                return View();
            }
            else
            {
                user.ParentId = userparent.Id;
                user.SponserId = usersponser.Id;
            }
            user.MemberShipLevelId = 1;
            db.Users.Add(user);
            db.SaveChanges();
            //REGISTER USER ROLE
            RoleUser roleuser = new RoleUser();
            roleuser.RoleId = 2;
            roleuser.UserId = user.Id;
            db.RoleUsers.Add(roleuser);
            db.SaveChanges();

            string To = user.Email, UserID, Password, SMTPPort, Host;

            var lnkHref = "<a href='http://incomeplant.azurewebsites.net/Account/login'>Click this to login your account</a>";

            string subject = "Welcome To Income Plant";

            string body = "<b>Congratulation!!! <br/> Your account has been successfully created.<br/> We warmly welcome you to our family and appreciate your interest for joining us.</b><br/>" + "</br>" + lnkHref + "<br/>" + "<p>If you did not make this request then you can simply ignore this email.</p><br/><p>Thanks,<br/><br/><b>Incomeplant Support</b></p>" + "<hr>" + "<img src='http://incomeplant.com/images/header-logo.png'/>" + "<br/>" + "<b>Telephone:</b> +91-8218-041-593 <p><b>Website: </b>http://incomeplant.com/</p>" + "<br/>" + "<p style='font-size: 10px;'><b>Address:</b>Harora Road, Simbhaoli, Hapur-245207</p></br><p style='font-size: 10px;'><b>Disclaimer:</b> This message (and any attachments) is private and confidential and may contain personal data or personal views which are not the views of Incomeplant unless specifically stated. If you have received this message in error, please notify us and remove it from your system. Do not use, copy or disclose the information in any way.</p>";

            //Get and set the AppSettings using configuration manager.  

            emailmanager.Appsettings(out UserID, out Password, out SMTPPort, out Host);

            //Call send email methods.  

            emailmanager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host); 

            ViewBag.Msg = "Register Successfully! ";
            return View();
        }

        public ActionResult signout()
        {
            AuthenticationManager.SignOut(); 
            HttpCookie c = new HttpCookie(".AspNet.ApplicationCookie");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c); 

            HttpCookie d = new HttpCookie("__RequestVerificationToken");
            d.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(d);

            return RedirectToAction("login", "Account");
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}

