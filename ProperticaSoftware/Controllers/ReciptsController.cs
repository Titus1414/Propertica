using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProperticaSoftware.Models;

namespace ProperticaSoftware.Controllers
{
    public class ReciptsController : Controller
    {
        private SoftDBEntities db = new SoftDBEntities();

        // GET: Recipts
        public ActionResult Index()
        {
            var recipts = db.Recipts.Include(r => r.Account).Include(r => r.Employe);
            return View(recipts.ToList());
        }

        // GET: Recipts/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Recipt recipt = db.Recipts.Find(id);
            //if (recipt == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(recipt);
            return View();
        }

        // GET: Recipts/Create
        public ActionResult Create()
        {
            ViewBag.Aid = new SelectList(db.Accounts, "Id", "Name");
            ViewBag.RecByEid = new SelectList(db.Employes, "Id", "Name");
            return View();
        }

        // POST: Recipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Aid,Amount,RecDate,RecByEid,IsActive")] Recipt recipt)
        {
            if (ModelState.IsValid)
            {
                db.Recipts.Add(recipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Aid = new SelectList(db.Accounts, "Id", "Name", recipt.Aid);
            ViewBag.RecByEid = new SelectList(db.Employes, "Id", "Name", recipt.RecByEid);
            return View(recipt);
        }

        // GET: Recipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipt recipt = db.Recipts.Find(id);
            if (recipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aid = new SelectList(db.Accounts, "Id", "Name", recipt.Aid);
            ViewBag.RecByEid = new SelectList(db.Employes, "Id", "Name", recipt.RecByEid);
            return View(recipt);
        }

        // POST: Recipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Aid,Amount,RecDate,RecByEid,IsActive")] Recipt recipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Aid = new SelectList(db.Accounts, "Id", "Name", recipt.Aid);
            ViewBag.RecByEid = new SelectList(db.Employes, "Id", "Name", recipt.RecByEid);
            return View(recipt);
        }

        // GET: Recipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipt recipt = db.Recipts.Find(id);
            if (recipt == null)
            {
                return HttpNotFound();
            }
            return View(recipt);
        }

        // POST: Recipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipt recipt = db.Recipts.Find(id);
            db.Recipts.Remove(recipt);
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
