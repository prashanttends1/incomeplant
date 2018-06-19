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

namespace mlmStudio.Controllers
{
    public class LedgerAccountController : Controller
    { 
        // GET: /LedgerAccount/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET LedgerAccount/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.LedgerAccounts.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.LedgerAccountType_LedgerAccountTypeId.Title), 
            Convert.ToString(c.Currency), 
            Convert.ToString(c.AccountCode), 
            Convert.ToString(c.AccountColor), 
            Convert.ToString(c.ParentId),
Convert.ToString(c.User_UserId.Username), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /LedgerAccount/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /LedgerAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedgerAccount ObjLedgerAccount = db.LedgerAccounts.Find(id);
            if (ObjLedgerAccount == null)
            {
                return HttpNotFound();
            }
            return View(ObjLedgerAccount);
        }
        // GET: /LedgerAccount/Create
        public ActionResult Create()
        {
             ViewBag.LedgerAccountTypeId = new SelectList(db.LedgerAccountTypes, "Id", "Title");
ViewBag.ParentId = new SelectList(db.LedgerAccounts, "Id", "Title");
ViewBag.UserId = new SelectList(db.Users, "Id", "Username");

             return View();
        }

        // POST: /LedgerAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(LedgerAccount ObjLedgerAccount )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.LedgerAccounts.Add(ObjLedgerAccount);
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
        // GET: /LedgerAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedgerAccount ObjLedgerAccount = db.LedgerAccounts.Find(id);
            if (ObjLedgerAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.LedgerAccountTypeId = new SelectList(db.LedgerAccountTypes, "Id", "Title", ObjLedgerAccount.LedgerAccountTypeId);
ViewBag.ParentId = new SelectList(db.LedgerAccounts, "Id", "Title", ObjLedgerAccount.ParentId);
ViewBag.UserId = new SelectList(db.Users, "Id", "Username", ObjLedgerAccount.UserId);

            return View(ObjLedgerAccount);
        }

        // POST: /LedgerAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(LedgerAccount ObjLedgerAccount )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjLedgerAccount).State = EntityState.Modified;
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
        // GET: /LedgerAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedgerAccount ObjLedgerAccount = db.LedgerAccounts.Find(id);
            if (ObjLedgerAccount == null)
            {
                return HttpNotFound();
            }
            return View(ObjLedgerAccount);
        }

        // POST: /LedgerAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    LedgerAccount ObjLedgerAccount = db.LedgerAccounts.Find(id);
                    db.LedgerAccounts.Remove(ObjLedgerAccount);
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
        // GET: /LedgerAccount/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            LedgerAccount ObjLedgerAccount = db.LedgerAccounts.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.LedgerAccountTypeId = new SelectList(db.LedgerAccountTypes, "Id", "Title", ObjLedgerAccount.LedgerAccountTypeId);
ViewBag.ParentId = new SelectList(db.LedgerAccounts, "Id", "Title", ObjLedgerAccount.ParentId);
ViewBag.UserId = new SelectList(db.Users, "Id", "Username", ObjLedgerAccount.UserId);

            }
            
            return View(ObjLedgerAccount);
        }

        // POST: /LedgerAccount/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(LedgerAccount ObjLedgerAccount )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjLedgerAccount).State = EntityState.Modified;
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
         public ActionResult TransactionGetGrid(int id=0)
        {
            var tak = db.Transactions.Where(i=>i.CreditLedgerAccountId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Title),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.CompanyOfficeId),
                Convert.ToString(c.DebitLedgerAccountId),
                Convert.ToString(c.DebitAmount),
                Convert.ToString(c.CreditLedgerAccountId),
                Convert.ToString(c.CreditAmount),
                Convert.ToString(c.TransactionDate),
                 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
         public ActionResult TransactionGetGrid1(int id=0)
        {
            var tak = db.Transactions.Where(i=>i.CreditLedgerAccountId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Title),
                Convert.ToString(c.DateAdded),
                Convert.ToString(c.AddedBy),
                Convert.ToString(c.CompanyOfficeId),
                Convert.ToString(c.DebitLedgerAccountId),
                Convert.ToString(c.DebitAmount),
                Convert.ToString(c.CreditLedgerAccountId),
                Convert.ToString(c.CreditAmount),
                Convert.ToString(c.TransactionDate),
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

