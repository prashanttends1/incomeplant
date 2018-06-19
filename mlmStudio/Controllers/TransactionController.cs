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
    public class TransactionController : Controller
    { 
        // GET: /Transaction/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET Transaction/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Transactions.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.AddedBy), 
            Convert.ToString(c.CompanyOfficeId), 
            Convert.ToString(c.LedgerAccount_DebitLedgerAccountId !=null?c.LedgerAccount_DebitLedgerAccountId.Title:""), 
            Convert.ToString(c.DebitAmount), 
            Convert.ToString(c.LedgerAccount_CreditLedgerAccountId !=null?c.LedgerAccount_CreditLedgerAccountId.Title:""), 
            Convert.ToString(c.CreditAmount), 
            Convert.ToString(c.TransactionDate), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Transaction/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction ObjTransaction = db.Transactions.Find(id);
            if (ObjTransaction == null)
            {
                return HttpNotFound();
            }
            return View(ObjTransaction);
        }
        // GET: /Transaction/Create
        public ActionResult Create()
        {
             ViewBag.DebitLedgerAccountId = new SelectList(db.LedgerAccounts, "Id", "Title");
ViewBag.CreditLedgerAccountId = new SelectList(db.LedgerAccounts, "Id", "Title");

             return View();
        }

        // POST: /Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Transaction ObjTransaction )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Transactions.Add(ObjTransaction);
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
        // GET: /Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction ObjTransaction = db.Transactions.Find(id);
            if (ObjTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.DebitLedgerAccountId = new SelectList(db.LedgerAccounts, "Id", "Title", ObjTransaction.DebitLedgerAccountId);
ViewBag.CreditLedgerAccountId = new SelectList(db.LedgerAccounts, "Id", "Title", ObjTransaction.CreditLedgerAccountId);

            return View(ObjTransaction);
        }

        // POST: /Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Transaction ObjTransaction )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjTransaction).State = EntityState.Modified;
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
        // GET: /Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction ObjTransaction = db.Transactions.Find(id);
            if (ObjTransaction == null)
            {
                return HttpNotFound();
            }
            return View(ObjTransaction);
        }

        // POST: /Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    Transaction ObjTransaction = db.Transactions.Find(id);
                    db.Transactions.Remove(ObjTransaction);
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
        // GET: /Transaction/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Transaction ObjTransaction = db.Transactions.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.DebitLedgerAccountId = new SelectList(db.LedgerAccounts, "Id", "Title", ObjTransaction.DebitLedgerAccountId);
ViewBag.CreditLedgerAccountId = new SelectList(db.LedgerAccounts, "Id", "Title", ObjTransaction.CreditLedgerAccountId);

            }
            
            return View(ObjTransaction);
        }

        // POST: /Transaction/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Transaction ObjTransaction )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjTransaction).State = EntityState.Modified;
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
         public ActionResult DonationTransactionGetGrid(int id=0)
        {
            var tak = db.DonationTransactions.Where(i=>i.TransactionId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.DonationRequest_DonationRequestId.Id),Convert.ToString(c.TransactionId),
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

