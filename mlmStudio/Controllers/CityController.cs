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
    public class CityController : Controller
    { 
        // GET: /City/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET City/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Citys.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Name), 
            Convert.ToString(c.Latitude), 
            Convert.ToString(c.Longitude), 
            Convert.ToString(c.IsActive), 
            Convert.ToString(c.State_StateId.Name), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /City/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /City/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City ObjCity = db.Citys.Find(id);
            if (ObjCity == null)
            {
                return HttpNotFound();
            }
            return View(ObjCity);
        }
        // GET: /City/Create
        public ActionResult Create()
        {
             ViewBag.StateId = new SelectList(db.States, "Id", "Name");

             return View();
        }

        // POST: /City/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(City ObjCity )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Citys.Add(ObjCity);
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
        // GET: /City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City ObjCity = db.Citys.Find(id);
            if (ObjCity == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.States, "Id", "Name", ObjCity.StateId);

            return View(ObjCity);
        }

        // POST: /City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(City ObjCity )
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjCity).State = EntityState.Modified;
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
        // GET: /City/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City ObjCity = db.Citys.Find(id);
            if (ObjCity == null)
            {
                return HttpNotFound();
            }
            return View(ObjCity);
        }

        // POST: /City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    City ObjCity = db.Citys.Find(id);
                    db.Citys.Remove(ObjCity);
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
        // GET: /City/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            City ObjCity = db.Citys.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.StateId = new SelectList(db.States, "Id", "Name", ObjCity.StateId);

            }
            
            return View(ObjCity);
        }

        // POST: /City/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(City ObjCity )
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    

                    db.Entry(ObjCity).State = EntityState.Modified;
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
         public ActionResult UserPersonalInfoGetGrid(int id=0)
        {
            var tak = db.UserPersonalInfos.Where(i=>i.CityId==id).ToArray();
             
            var result = from c in tak select new string[] { Convert.ToString(c.Id),Convert.ToString(c.Id),
                Convert.ToString(c.FirstName),
                Convert.ToString(c.LastName),
                Convert.ToString(c.Gender_GenderId.Name),Convert.ToString(c.About),
                Convert.ToString(c.ProfileImage),
                Convert.ToString(c.DateJoin),
                Convert.ToString(c.User_UserId.Username),Convert.ToString(c.MiddleName),
                Convert.ToString(c.Email),
                Convert.ToString(c.FatherAndSpouseName),
                Convert.ToString(c.DOB),
                Convert.ToString(c.MotherName),
                Convert.ToString(c.NomineName),
                Convert.ToString(c.CityId),
                Convert.ToString(c.ZipCode),
                Convert.ToString(c.PanNumber),
                Convert.ToString(c.EducationDetail),
                Convert.ToString(c.LastEmployeeFirm),
                Convert.ToString(c.LastEmployeeYear),
                Convert.ToString(c.LastEmployeeAnualIncome),
                Convert.ToString(c.IsActive),
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

