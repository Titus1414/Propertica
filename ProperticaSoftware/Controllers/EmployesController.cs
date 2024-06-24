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
    public class EmployesController : Controller
    {
        private SoftDBEntities db = new SoftDBEntities();

        // GET: Employes
        public ActionResult Index()
        {
            //var employes = db.Employes.Include(e => e.Attendence).Include(e => e.AttendenceRecord).Include(e => e.Department).Include(e => e.Designation).Include(e => e.User);
            // return View(employes.ToList());
            return View();
        }

        // GET: Employes/Details/5
        public ActionResult Details(int? id)
        {
            //Scapfolded code to check id and generate error/////////////////////////////////////////
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Employe employe = db.Employes.Find(id);
            //if (employe == null)
            //{
            //    return HttpNotFound();
            //}
            // return View(employe);
            //////////////////////////////////////////////////////////////////////////////////
            return View();

        }

        public ActionResult EmployDetail()
        {


            return View();

        }

        // GET: Employes/Create
        public ActionResult Create()
        {
            ViewBag.Atid = new SelectList(db.Attendences, "Id", "Time");
            ViewBag.Atrid = new SelectList(db.AttendenceRecords, "Id", "Time");
            ViewBag.Did = new SelectList(db.Departments, "Id", "Name");
            ViewBag.Dsid = new SelectList(db.Designations, "Id", "Name");
            ViewBag.Uid = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Employes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Uid,Did,Dsid,Atid,Atrid,Name,Age,CNIC,DateOfBirth,Email,Address,PhoneNo,Landline,JoiningDate,TerminationDate,Picture")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Employes.Add(employe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Atid = new SelectList(db.Attendences, "Id", "Time", employe.Atid);
            ViewBag.Atrid = new SelectList(db.AttendenceRecords, "Id", "Time", employe.Atrid);
            ViewBag.Did = new SelectList(db.Departments, "Id", "Name", employe.Did);
            ViewBag.Dsid = new SelectList(db.Designations, "Id", "Name", employe.Dsid);
            ViewBag.Uid = new SelectList(db.Users, "Id", "Email", employe.Uid);
            return View(employe);
        }

        // GET: Employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            ViewBag.Atid = new SelectList(db.Attendences, "Id", "Time", employe.Atid);
            ViewBag.Atrid = new SelectList(db.AttendenceRecords, "Id", "Time", employe.Atrid);
            ViewBag.Did = new SelectList(db.Departments, "Id", "Name", employe.Did);
            ViewBag.Dsid = new SelectList(db.Designations, "Id", "Name", employe.Dsid);
            ViewBag.Uid = new SelectList(db.Users, "Id", "Email", employe.Uid);
            return View(employe);
        }

        // POST: Employes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Uid,Did,Dsid,Atid,Atrid,Name,Age,CNIC,DateOfBirth,Email,Address,PhoneNo,Landline,JoiningDate,TerminationDate,Picture")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Atid = new SelectList(db.Attendences, "Id", "Time", employe.Atid);
            ViewBag.Atrid = new SelectList(db.AttendenceRecords, "Id", "Time", employe.Atrid);
            ViewBag.Did = new SelectList(db.Departments, "Id", "Name", employe.Did);
            ViewBag.Dsid = new SelectList(db.Designations, "Id", "Name", employe.Dsid);
            ViewBag.Uid = new SelectList(db.Users, "Id", "Email", employe.Uid);
            return View(employe);
        }

        // GET: Employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employe employe = db.Employes.Find(id);
            db.Employes.Remove(employe);
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
