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
    public class UserContactInfoController : Controller
    { 
        // GET: /UserContactInfo/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET UserContactInfo/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserContactInfos.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.ContactType_ContactTypeId.TypeName), 
            Convert.ToString(c.ContactDetail), 
            Convert.ToString(c.User_UserId.Username), 
            Convert.ToString(c.IsActive), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /UserContactInfo/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserContactInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContactInfo ObjUserContactInfo = db.UserContactInfos.Find(id);
            if (ObjUserContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserContactInfo);
        }
        // GET: /UserContactInfo/Create
        public ActionResult Create()
        {
             ViewBag.ContactTypeId = new SelectList(db.ContactTypes, "Id", "TypeName");
ViewBag.UserId = new SelectList(db.Users, "Id", "Username");

             return View();
        }

        // POST: /UserContactInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserContactInfo ObjUserContactInfo )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.UserContactInfos.Add(ObjUserContactInfo);
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
        // GET: /UserContactInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContactInfo ObjUserContactInfo = db.UserContactInfos.Find(id);
            if (ObjUserContactInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactTypeId = new SelectList(db.ContactTypes, "Id", "TypeName", ObjUserContactInfo.ContactTypeId);
ViewBag.UserId = new SelectList(db.Users, "Id", "Username", ObjUserContactInfo.UserId);

            return View(ObjUserContactInfo);
        }

        // POST: /UserContactInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserContactInfo ObjUserContactInfo )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjUserContactInfo).State = EntityState.Modified;
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
        // GET: /UserContactInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContactInfo ObjUserContactInfo = db.UserContactInfos.Find(id);
            if (ObjUserContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserContactInfo);
        }

        // POST: /UserContactInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    UserContactInfo ObjUserContactInfo = db.UserContactInfos.Find(id);
                    db.UserContactInfos.Remove(ObjUserContactInfo);
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
        // GET: /UserContactInfo/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            UserContactInfo ObjUserContactInfo = db.UserContactInfos.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.ContactTypeId = new SelectList(db.ContactTypes, "Id", "TypeName", ObjUserContactInfo.ContactTypeId);
ViewBag.UserId = new SelectList(db.Users, "Id", "Username", ObjUserContactInfo.UserId);

            }
            
            return View(ObjUserContactInfo);
        }

        // POST: /UserContactInfo/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserContactInfo ObjUserContactInfo )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjUserContactInfo).State = EntityState.Modified;
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

