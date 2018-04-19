using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Institution.Models;

namespace Institution.Controllers
{
    public class HomeController : Controller
    {
        private InstitutionContext db = new InstitutionContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View(new Student());
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,FatherName,MotherName,DOB,Email,Phone,ImageUpload,Gender")] Student student)
        {
            string validImageFormets = @"bmp, jpg, jpeg, gif, png";

            if (ModelState.IsValid)
            {
                if (student.ImageUpload == null || student.ImageUpload.ContentLength == 0) ModelState.AddModelError("ImageUpload", "This field is required");
                else if (!validImageFormets.Contains(student.ImageUpload.FileName.Split('.').Last())) ModelState.AddModelError("ImageUpload", "Upload a valid image, allowed formats are : " + validImageFormets);
                else
                {
                    var fileName = DateTime.UtcNow.ToString().Replace(" ", string.Empty).Replace(":", string.Empty).Replace("/", string.Empty) + student.ImageUpload.FileName.Replace(" ", string.Empty);
                    student.ImageUrl = @"\images\" + fileName;
                    student.ImageUpload.SaveAs(Server.MapPath("~/images/" + fileName));
                    db.Students.Add(student);
                    if (student.StudentId > 0) db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View("Create", student);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
