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
    public class ePinRequestController : Controller
    { 
        // GET: /ePinRequest/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET ePinRequest/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.ePinRequests.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.Qty), 
            Convert.ToString(c.User_FromUserId.Username), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.IsApproved), 
            Convert.ToString(c.ApprovedBy), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /ePinRequest/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /ePinRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ePinRequest ObjePinRequest = db.ePinRequests.Find(id);
            if (ObjePinRequest == null)
            {
                return HttpNotFound();
            }
            return View(ObjePinRequest);
        }
        // GET: /ePinRequest/Create
        public ActionResult Create()
        {
             ViewBag.FromUserId = new SelectList(db.Users, "Id", "Username");

             return View();
        }

        // POST: /ePinRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ePinRequest ObjePinRequest )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.ePinRequests.Add(ObjePinRequest);
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
        // GET: /ePinRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ePinRequest ObjePinRequest = db.ePinRequests.Find(id);
            if (ObjePinRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromUserId = new SelectList(db.Users, "Id", "Username", ObjePinRequest.FromUserId);

            return View(ObjePinRequest);
        }

        // POST: /ePinRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ePinRequest ObjePinRequest )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjePinRequest).State = EntityState.Modified;
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
        // GET: /ePinRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ePinRequest ObjePinRequest = db.ePinRequests.Find(id);
            if (ObjePinRequest == null)
            {
                return HttpNotFound();
            }
            return View(ObjePinRequest);
        }

        // POST: /ePinRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    ePinRequest ObjePinRequest = db.ePinRequests.Find(id);
                    db.ePinRequests.Remove(ObjePinRequest);
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
        // GET: /ePinRequest/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            ePinRequest ObjePinRequest = db.ePinRequests.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.FromUserId = new SelectList(db.Users, "Id", "Username", ObjePinRequest.FromUserId);

            }
            
            return View(ObjePinRequest);
        }

        // POST: /ePinRequest/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(ePinRequest ObjePinRequest )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjePinRequest).State = EntityState.Modified;
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
         public ActionResult ePinCodeGetGrid(int id=0)
        {
            var tak = db.ePinCodes.Where(i=>i.ePinRequestId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.ePinRequestId),
                Convert.ToString(c.PCode),
                Convert.ToString(c.DateAdded),
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

