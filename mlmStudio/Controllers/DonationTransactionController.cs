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
    public class DonationTransactionController : Controller
    { 
        // GET: /DonationTransaction/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET DonationTransaction/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.DonationTransactions.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.DonationRequest_DonationRequestId.Id), 
            Convert.ToString(c.Transaction_TransactionId.Title), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /DonationTransaction/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /DonationTransaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationTransaction ObjDonationTransaction = db.DonationTransactions.Find(id);
            if (ObjDonationTransaction == null)
            {
                return HttpNotFound();
            }
            return View(ObjDonationTransaction);
        }
        // GET: /DonationTransaction/Create
        public ActionResult Create()
        {
             ViewBag.DonationRequestId = new SelectList(db.DonationRequests, "Id", "Id");
ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Title");

             return View();
        }

        // POST: /DonationTransaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(DonationTransaction ObjDonationTransaction )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.DonationTransactions.Add(ObjDonationTransaction);
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
        // GET: /DonationTransaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationTransaction ObjDonationTransaction = db.DonationTransactions.Find(id);
            if (ObjDonationTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonationRequestId = new SelectList(db.DonationRequests, "Id", "Id", ObjDonationTransaction.DonationRequestId);
ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Title", ObjDonationTransaction.TransactionId);

            return View(ObjDonationTransaction);
        }

        // POST: /DonationTransaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(DonationTransaction ObjDonationTransaction )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjDonationTransaction).State = EntityState.Modified;
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
        // GET: /DonationTransaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationTransaction ObjDonationTransaction = db.DonationTransactions.Find(id);
            if (ObjDonationTransaction == null)
            {
                return HttpNotFound();
            }
            return View(ObjDonationTransaction);
        }

        // POST: /DonationTransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    DonationTransaction ObjDonationTransaction = db.DonationTransactions.Find(id);
                    db.DonationTransactions.Remove(ObjDonationTransaction);
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
        // GET: /DonationTransaction/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            DonationTransaction ObjDonationTransaction = db.DonationTransactions.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.DonationRequestId = new SelectList(db.DonationRequests, "Id", "Id", ObjDonationTransaction.DonationRequestId);
ViewBag.TransactionId = new SelectList(db.Transactions, "Id", "Title", ObjDonationTransaction.TransactionId);

            }
            
            return View(ObjDonationTransaction);
        }

        // POST: /DonationTransaction/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(DonationTransaction ObjDonationTransaction )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjDonationTransaction).State = EntityState.Modified;
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

