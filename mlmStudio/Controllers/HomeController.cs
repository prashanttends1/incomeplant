using mlmStudio.ModelDto;
using mlmStudio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace mlmStudio.Controllers
{
    public class HomeController : Controller
    {
        private SIContext db = new SIContext();
	   
        public ActionResult Index()
        {
            var CurerntDate = DateTime.Now.Date;
            var LastSevenDays  = DateTime.Now.Date.AddDays(-7);
            StringBuilder sb = new StringBuilder();
            try
            {
                var LastWeekRegister = db.UserPersonalInfos.Where(i => i.DateJoin >= LastSevenDays).ToArray();
                for (int i = 0; i < 7; i++)
                {

                    var dateDynamic = DateTime.Now.Date.AddDays(-i);
                    int year = dateDynamic.Year;
                    int month = dateDynamic.Month;
                    int day = dateDynamic.Day;

                    DateTime newDate = new DateTime(year, month, day);
                    var hav = LastWeekRegister.Where(j => j.DateJoin.Date == newDate.Date).ToArray();
                    if (hav.Any())
                    {
                        sb.AppendLine("{ y:'" + newDate.ToString("yyyy-MM-dd") + "',User: " + hav.Count() + " },");
                    }
                    else
                    {
                        sb.AppendLine("{ y:'" + newDate.ToString("yyyy-MM-dd") + "',User: 0 },");
                    }

                }
                ViewBag.linechart = sb.ToString().TrimEnd(',');
            
            }
            catch (Exception)
            {
                 
            }
            
            homeDto h = new homeDto();
            h.User = db.Users.Count();
            h.Role = db.Roles.Count();
            h.ePinRequest = db.ePinRequests.Count(i=>i.IsApproved==false);
            h.Country = db.Countrys.Count();
            h.LedgerAccount = db.LedgerAccounts.Count();
            h.PaymentStatus = db.PaymentStatuss.Count();
            h.Reward = db.Rewards.Count();
            h.Transaction = db.Transactions.Count();
            h.Product = db.Products.Count();



            ViewBag.Users = db.Users.Count();
            ViewBag.Roles = db.Roles.Count();

            ViewBag.UserBankInfos = db.UserBankInfos.Count();
            ViewBag.UserPersonalInfos = db.UserPersonalInfos.Count();
            ViewBag.UserContactInfos = db.UserContactInfos.Count();



            return View(h);
        }



        public JsonResult ApproveEpins()
        {
            List<string> li = new List<string>();
            try
            {
                var epr = db.ePinRequests.ToArray();
                foreach (var item in epr)
                {
                    for (int i = 0; i < item.Qty; i++)
                    {
                        ePinCode ObjePinCode = new ePinCode();
                        ObjePinCode.DateAdded = DateTime.Now;
                        ObjePinCode.ePinRequestId = item.Id; 
                        Guid guid = Guid.NewGuid();
                        ObjePinCode.PCode = guid.ToString().Substring(0,32);
                        db.ePinCodes.Add(ObjePinCode);
                        db.SaveChanges();
                    }
                    var ObjePinRequest = item;
                    ObjePinRequest.IsApproved = true;
                    ObjePinRequest.ApprovedBy = int.Parse(Env.GetUserInfo("userid"));
                    db.Entry(ObjePinRequest).State = EntityState.Modified;
                    db.SaveChanges();
                }

                li.Add("Done");
            }
            catch (Exception)
            {
                li.Add("Error");
            }
            return Json(li, JsonRequestBehavior.AllowGet);
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
