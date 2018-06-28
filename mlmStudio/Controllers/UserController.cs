using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using mlmStudio.Models;
using mlmStudio.ModelDto.Tree;
using mlmStudio.ModelDto;

namespace mlmStudio.Controllers
{
    
    public class UserController : Controller
    {
        // GET: /User/
        
        public ActionResult Index()
        {
            if (Env.GetUserInfo("roleid") == "1" )
                return View();            
            else
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }

        public ActionResult Tree()
        {
            return View();
        }


       
        public JsonResult gettree()
        {
            var pcTable = db.Users.ToArray();

            List<RootObject> root = new List<RootObject>();
             
            foreach (var item in pcTable.Where(i => i.ParentId == null))
            {
                RootObject liroot = new RootObject();
                liroot.id = item.Id;
                liroot.text = item.Username;

                var CheckInner = pcTable.FirstOrDefault(j => j.ParentId == item.Id);
                if (CheckInner != null)
                {
                    liroot.children = TreeChile(pcTable, item.Id);
                }

                root.Add(liroot);
            }

            return Json(root, JsonRequestBehavior.AllowGet);
        }
         

        public List<Child> TreeChile(User[] pcTable, int itemId)
        {
            List<Child> childList = new List<Child>();
            foreach (var inner in pcTable.Where(j => j.ParentId == itemId))
            {
                Child chileli = new Child();
                chileli.id = inner.Id;
                chileli.text = inner.Username;
                //chileli.@checked = null;
                //chileli.state = "";

                var CheckInner = pcTable.FirstOrDefault(j => j.ParentId == inner.Id);
                if (CheckInner != null)
                {
                    chileli.children = TreeChile(pcTable, inner.Id);
                }

                childList.Add(chileli);
            }
            return childList;
        }

        
         

        public ActionResult TreeLegs()
        { 
            return View();
        }




        public JsonResult GetTreeOrg()
        {
            var pcTable = db.Users.ToArray();

            List<TreeOrg> empChartList = new List<TreeOrg>();

            foreach (var item in pcTable)
            {
                empChartList.Add(new TreeOrg()
                {
                    Id = item.Id,
                    UserName = item.Username,
                    Designation = item.Username,
                    Leg = item.Leg_LegId.Name,
                    ParentId = item.ParentId==null?0:item.ParentId.Value
                });
            }
                       

            return Json(empChartList, JsonRequestBehavior.AllowGet);  
        }
 
         

        public ActionResult GetGrid()
        {
            var tak = db.Users.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Username), 
            Convert.ToString(c.Password), 
            Convert.ToString(c.ParentId),
            Convert.ToString(c.SponserId),
            Convert.ToString(c.Leg_LegId !=null?c.Leg_LegId.Name:""), 
            Convert.ToString(c.MemberShipLevel_MemberShipLevelId.Title), 
            Convert.ToString(c.RegisterPin), Convert.ToString(c.ProductId), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /User/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User ObjUser = db.Users.Find(id);
            if (ObjUser == null)
            {
                return HttpNotFound();
            }
            return View(ObjUser);
        }
        // GET: /User/Create
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(db.Users, "Id", "Username");
            ViewBag.SponserId = new SelectList(db.Users, "Id", "Username");
            ViewBag.LegId = new SelectList(db.Legs, "Id", "Name");
            ViewBag.MemberShipLevelId = new SelectList(db.MemberShipLevels, "Id", "Title");

            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(User ObjUser)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Users.Add(ObjUser);
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }

            return Content(sb.ToString());

        }
        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User ObjUser = db.Users.Find(id);

            if (ObjUser == null )
            {
                return HttpNotFound();
            }
            else if (User.Identity.Name == ObjUser.Username || Env.GetUserInfo("roleid")=="1")
            {
                ViewBag.ParentId = new SelectList(db.Users, "Id", "Username", ObjUser.ParentId);
                ViewBag.SponserId = new SelectList(db.Users, "Id", "Username", ObjUser.SponserId);
                ViewBag.LegId = new SelectList(db.Legs, "Id", "Name", ObjUser.LegId);
                ViewBag.MemberShipLevelId = new SelectList(db.MemberShipLevels, "Id", "Title", ObjUser.MemberShipLevelId);

                return View(ObjUser);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(User ObjUser)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUser).State = EntityState.Modified;
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }


            return Content(sb.ToString());

        }
        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User ObjUser = db.Users.Find(id);
            if (ObjUser == null)
            {
                return HttpNotFound();
            }
            return View(ObjUser);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                User ObjUser = db.Users.Find(id);
                db.Users.Remove(ObjUser);
                db.SaveChanges();

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }

            return Content(sb.ToString());

        }
        // GET: /User/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            User ObjUser = db.Users.Find(id);
            if (User.Identity.Name == ObjUser.Username || Env.GetUserInfo("roleid") == "1")
            {
                ViewBag.IsWorking = 0;
                if (id > 0)
                {
                    ViewBag.IsWorking = id;
                    ViewBag.ParentId = new SelectList(db.Users, "Id", "Username", ObjUser.ParentId);
                    ViewBag.SponserId = new SelectList(db.Users, "Id", "Username", ObjUser.SponserId);
                    ViewBag.LegId = new SelectList(db.Legs, "Id", "Name", ObjUser.LegId);
                    ViewBag.MemberShipLevelId = new SelectList(db.MemberShipLevels, "Id", "Title", ObjUser.MemberShipLevelId);

                }

                return View(ObjUser);
            }
            else
            {
               return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }


        public JsonResult BarChart(int Id)
        {
            List<GraphData> dataList = new List<GraphData>();
          
            GraphData ru = new GraphData();
            ru.label = "Role User";
            ru.value = db.RoleUsers.Where(i => i.UserId == Id).Count();
            dataList.Add(ru);
             
            GraphData ma = new GraphData();
            ma.label = "Menu Access";
            ma.value = db.MenuPermissions.Where(i => i.UserId == Id).Count();
            dataList.Add(ma);

            GraphData pi = new GraphData();
            pi.label = "Personal Info";
            pi.value = db.UserPersonalInfos.Where(i => i.UserId == Id).Count();
            dataList.Add(pi);

            GraphData ci = new GraphData();
            ci.label = "Contact Info";
            ci.value = db.UserContactInfos.Where(i => i.UserId == Id).Count();
            dataList.Add(ci);

            GraphData bi = new GraphData();
            bi.label = "Bank Info";
            bi.value = db.UserBankInfos.Where(i => i.UserId == Id).Count();
            dataList.Add(bi);

            GraphData ur = new GraphData();
            ur.label = "Reward";
            ur.value = db.RewardUsers.Where(i => i.UserId == Id).Count();
            dataList.Add(ur);

            GraphData ep = new GraphData();
            ep.label = "ePin Requests";
            ep.value = db.ePinRequests.Where(i => i.FromUserId == Id).Count();
            dataList.Add(ep);
 

            GraphData la = new GraphData();
            la.label = "Ledger Account";
            la.value = db.LedgerAccounts.Where(i => i.UserId == Id).Count();
            dataList.Add(la);


            return Json(dataList, JsonRequestBehavior.AllowGet);
        }
        private class GraphData
        {
            public string label { get; set; }
            public Nullable<int> value { get; set; }
        }

        // POST: /User/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(User ObjUser)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {


                    db.Entry(ObjUser).State = EntityState.Modified;
                    db.SaveChanges();

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }

            return Content(sb.ToString());

        }
        public ActionResult RoleUserGetGrid(int id = 0)
        {
            var tak = db.RoleUsers.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Role_RoleId.RoleName),Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MenuPermissionGetGrid(int id = 0)
        {
            var tak = db.MenuPermissions.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Menu_MenuId.MenuText),Convert.ToString(c.Role_RoleId.RoleName),Convert.ToString(c.UserId),
                Convert.ToString(c.SortOrder),
                Convert.ToString(c.IsNavBar),
                Convert.ToString(c.IsCreate),
                Convert.ToString(c.IsRead),
                Convert.ToString(c.IsUpdate),
                Convert.ToString(c.IsDelete),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserPersonalInfoGetGrid(int id = 0)
        {
            var tak = db.UserPersonalInfos.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.FirstName),
                Convert.ToString(c.LastName),
                Convert.ToString(c.Gender_GenderId.Name),Convert.ToString(c.About),
                Convert.ToString(c.ProfileImage),
                Convert.ToString(c.DateJoin),
                Convert.ToString(c.UserId),
                Convert.ToString(c.MiddleName),
                Convert.ToString(c.Email),
                Convert.ToString(c.FatherAndSpouseName),
                Convert.ToString(c.DOB),
                Convert.ToString(c.MotherName),
                Convert.ToString(c.NomineName),
                Convert.ToString(c.City_CityId.Name),Convert.ToString(c.ZipCode),
                Convert.ToString(c.PanNumber),
                Convert.ToString(c.EducationDetail),
                Convert.ToString(c.LastEmployeeFirm),
                Convert.ToString(c.LastEmployeeYear),
                Convert.ToString(c.LastEmployeeAnualIncome),
                Convert.ToString(c.IsActive),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserContactInfoGetGrid(int id = 0)
        {
            var tak = db.UserContactInfos.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.ContactType_ContactTypeId.TypeName),Convert.ToString(c.ContactDetail),
                Convert.ToString(c.UserId),
                Convert.ToString(c.IsActive),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserBankInfoGetGrid(int id = 0)
        {
            var tak = db.UserBankInfos.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.AccountHolderName),
                Convert.ToString(c.UserId),
                Convert.ToString(c.BankName),
                Convert.ToString(c.AccountNumber),
                Convert.ToString(c.Branch),
                Convert.ToString(c.IFCI_Code),
                Convert.ToString(c.IsActive),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult InvoiceGetGrid(int id = 0)
        {
            var tak = db.Invoices.Where(i => i.ClientId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.BillDate),
                Convert.ToString(c.DueDate),
                Convert.ToString(c.PaymentStatus_Status.Title),Convert.ToString(c.LastEmailed),
                Convert.ToString(c.OtherInvoiceCode),
                Convert.ToString(c.ClientId),
                Convert.ToString(c.CreatedBy),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RewardUserGetGrid(int id = 0)
        {
            var tak = db.RewardUsers.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                Convert.ToString(c.Reward_RewardId.Title),Convert.ToString(c.Qty),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ePinRequestGetGrid(int id = 0)
        {
            var tak = db.ePinRequests.Where(i => i.FromUserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Title),
                Convert.ToString(c.Qty),
                Convert.ToString(c.FromUserId),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.IsApproved),
                Convert.ToString(c.ApprovedBy),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DonationRequestGetGrid(int id = 0)
        {
            var tak = db.DonationRequests.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.UserId),
                Convert.ToString(c.Amount),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.RequiredTill),
                Convert.ToString(c.IsActive),
                Convert.ToString(c.RequestNote),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LedgerAccountGetGrid(int id = 0)
        {
            var tak = db.LedgerAccounts.Where(i => i.UserId == id).ToArray();

            var result = from c in tak
                         select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Title),
                Convert.ToString(c.LedgerAccountType_LedgerAccountTypeId.Title),Convert.ToString(c.Currency),
                Convert.ToString(c.AccountCode),
                Convert.ToString(c.AccountColor),
                Convert.ToString(c.LedgerAccount2 !=null?c.LedgerAccount2.Title:""),Convert.ToString(c.UserId),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }

        private SIContext db = new SIContext();


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}

