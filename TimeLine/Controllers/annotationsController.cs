using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeLine.Models;

namespace TimeLine.Controllers
{
    [Authorize]
    public class annotationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: annotations
        public ActionResult Index()
        {
            return View(db.annotations.OrderByDescending(d=> d.entrydatetime).ToList());
        }

        // GET: annotations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            annotation annotation = db.annotations.Find(id);
            if (annotation == null)
            {
                return HttpNotFound();
            }
            return View(annotation);
        }

        // GET: annotations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: annotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,entrydatetime,datetime,subject,description,context,username")] annotation annotation)
        {
            if (ModelState.IsValid)
            {
                annotation.id = Guid.NewGuid();
                annotation.username = User.Identity.Name;
                db.annotations.Add(annotation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(annotation);
        }

        // GET: annotations/Create
        public ActionResult PartialCreate()
        {
            return PartialView();
        }

        // POST: annotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartialCreate([Bind(Include = "id,entrydatetime,datetime,subject,description,context,username")] annotation annotation)
        {
            if (ModelState.IsValid)
            {
                annotation.id = Guid.NewGuid();
                annotation.username = User.Identity.Name;
                db.annotations.Add(annotation);
                db.SaveChanges();
                return PartialView();
            }

            return PartialView();
        }



        // GET: annotations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            annotation annotation = db.annotations.Find(id);
            if (annotation == null)
            {
                return HttpNotFound();
            }
            return View(annotation);
        }

        // POST: annotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,entrydatetime,datetime,subject,description,context,username")] annotation annotation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(annotation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(annotation);
        }

        // GET: annotations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            annotation annotation = db.annotations.Find(id);
            if (annotation == null)
            {
                return HttpNotFound();
            }
            return View(annotation);
        }

        // POST: annotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            annotation annotation = db.annotations.Find(id);
            db.annotations.Remove(annotation);
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
