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
            user.MemberShipLevelId = 1;
            db.Users.Add(user);

            //REGISTER USER ROLE
            RoleUser roleuser = new RoleUser();
            roleuser.RoleId = 1;
            roleuser.UserId = user.Id;
            db.RoleUsers.Add(roleuser);
            db.SaveChanges();
            
            ViewBag.Msg = "Register Successfully";
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

