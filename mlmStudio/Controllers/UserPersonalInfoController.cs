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
    public class UserPersonalInfoController : Controller
    { 
        // GET: /UserPersonalInfo/
        public ActionResult Index()
        {
            return View();
        }
        
        // GET UserPersonalInfo/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.UserPersonalInfos.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.FirstName), 
            Convert.ToString(c.LastName), 
            Convert.ToString(c.Gender_GenderId.Name), 
            Convert.ToString(c.About), 
            Convert.ToString(c.ProfileImage), 
            Convert.ToString(c.DateJoin), 
            Convert.ToString(c.User_UserId.Username), 
            Convert.ToString(c.MiddleName), 
            Convert.ToString(c.Email), 
            Convert.ToString(c.FatherAndSpouseName), 
            Convert.ToString(c.DOB), 
            Convert.ToString(c.MotherName), 
            Convert.ToString(c.NomineName), 
            Convert.ToString(c.City_CityId.Name), 
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
        // GET: /UserPersonalInfo/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return View();
        }
        // GET: /UserPersonalInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPersonalInfo ObjUserPersonalInfo = db.UserPersonalInfos.Find(id);
            if (ObjUserPersonalInfo == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserPersonalInfo);
        }
        // GET: /UserPersonalInfo/Create
        public ActionResult Create()
        {
             ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
ViewBag.CityId = new SelectList(db.Citys, "Id", "Name");

             return View();
        }

        // POST: /UserPersonalInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(UserPersonalInfo ObjUserPersonalInfo ,HttpPostedFileBase ProfileImage,string HideImage1)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (ProfileImage != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(ProfileImage, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjUserPersonalInfo.ProfileImage = fileName; 
                    } 
                    else 
                    { 
                        ObjUserPersonalInfo.ProfileImage = HideImage1;  
                    }


                    db.UserPersonalInfos.Add(ObjUserPersonalInfo);
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
        // GET: /UserPersonalInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPersonalInfo ObjUserPersonalInfo = db.UserPersonalInfos.Find(id);
            if (ObjUserPersonalInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", ObjUserPersonalInfo.GenderId);
ViewBag.UserId = new SelectList(db.Users, "Id", "Username", ObjUserPersonalInfo.UserId);
ViewBag.CityId = new SelectList(db.Citys, "Id", "Name", ObjUserPersonalInfo.CityId);

            return View(ObjUserPersonalInfo);
        }

        // POST: /UserPersonalInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(UserPersonalInfo ObjUserPersonalInfo ,HttpPostedFileBase ProfileImage,string HideImage1)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (ProfileImage != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(ProfileImage, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjUserPersonalInfo.ProfileImage = fileName; 
                    } 
                    else 
                    { 
                        ObjUserPersonalInfo.ProfileImage = HideImage1;  
                    }


                    db.Entry(ObjUserPersonalInfo).State = EntityState.Modified;
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
        // GET: /UserPersonalInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPersonalInfo ObjUserPersonalInfo = db.UserPersonalInfos.Find(id);
            if (ObjUserPersonalInfo == null)
            {
                return HttpNotFound();
            }
            return View(ObjUserPersonalInfo);
        }

        // POST: /UserPersonalInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                  
                    UserPersonalInfo ObjUserPersonalInfo = db.UserPersonalInfos.Find(id);
                    db.UserPersonalInfos.Remove(ObjUserPersonalInfo);
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
        // GET: /UserPersonalInfo/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            UserPersonalInfo ObjUserPersonalInfo = db.UserPersonalInfos.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", ObjUserPersonalInfo.GenderId);
ViewBag.UserId = new SelectList(db.Users, "Id", "Username", ObjUserPersonalInfo.UserId);
ViewBag.CityId = new SelectList(db.Citys, "Id", "Name", ObjUserPersonalInfo.CityId);

            }
            
            return View(ObjUserPersonalInfo);
        }

        // POST: /UserPersonalInfo/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(UserPersonalInfo ObjUserPersonalInfo ,HttpPostedFileBase ProfileImage,string HideImage1)
        {  
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            try
            {
                if (ModelState.IsValid)
                { 
                    if (ProfileImage != null) 
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(ProfileImage, Server.MapPath("~/Uploads"));
                        ModelState.Clear(); 
                        ObjUserPersonalInfo.ProfileImage = fileName; 
                    } 
                    else 
                    { 
                        ObjUserPersonalInfo.ProfileImage = HideImage1;  
                    }


                    db.Entry(ObjUserPersonalInfo).State = EntityState.Modified;
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

