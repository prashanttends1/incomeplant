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
    public class MemberShipLevelController : Controller
    { 
        // GET: /MemberShipLevel/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET MemberShipLevel/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.MemberShipLevels.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /MemberShipLevel/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /MemberShipLevel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberShipLevel ObjMemberShipLevel = db.MemberShipLevels.Find(id);
            if (ObjMemberShipLevel == null)
            {
                return HttpNotFound();
            }
            return View(ObjMemberShipLevel);
        }
        // GET: /MemberShipLevel/Create
        public ActionResult Create()
        {
             
             return View();
        }

        // POST: /MemberShipLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(MemberShipLevel ObjMemberShipLevel )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.MemberShipLevels.Add(ObjMemberShipLevel);
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
        // GET: /MemberShipLevel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberShipLevel ObjMemberShipLevel = db.MemberShipLevels.Find(id);
            if (ObjMemberShipLevel == null)
            {
                return HttpNotFound();
            }
            
            return View(ObjMemberShipLevel);
        }

        // POST: /MemberShipLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(MemberShipLevel ObjMemberShipLevel )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjMemberShipLevel).State = EntityState.Modified;
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
        // GET: /MemberShipLevel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberShipLevel ObjMemberShipLevel = db.MemberShipLevels.Find(id);
            if (ObjMemberShipLevel == null)
            {
                return HttpNotFound();
            }
            return View(ObjMemberShipLevel);
        }

        // POST: /MemberShipLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    MemberShipLevel ObjMemberShipLevel = db.MemberShipLevels.Find(id);
                    db.MemberShipLevels.Remove(ObjMemberShipLevel);
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
        // GET: /MemberShipLevel/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            MemberShipLevel ObjMemberShipLevel = db.MemberShipLevels.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                
            }
            
            return View(ObjMemberShipLevel);
        }

        // POST: /MemberShipLevel/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(MemberShipLevel ObjMemberShipLevel )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjMemberShipLevel).State = EntityState.Modified;
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
         public ActionResult UserGetGrid(int id=0)
        {
            var tak = db.Users.Where(i=>i.MemberShipLevelId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.Username),
                Convert.ToString(c.Password),
                Convert.ToString(c.User2 !=null?c.User2.Username:""),Convert.ToString(c.Leg_LegId.Name),Convert.ToString(c.MemberShipLevelId),
                Convert.ToString(c.RegisterPin),
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

