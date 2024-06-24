using ProperticaSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProperticaSoftware.Controllers
{
    public class HomeController : Controller
    {
        SoftDBEntities db = new SoftDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult previousDay(string day)
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo myZone = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            DateTime custDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, myZone);

            DateTime todayDate = DateTime.Now;
            DateTime after3MonthDate = todayDate.AddMonths(3);

            DateTime date = Convert.ToDateTime(day);


            List<EmpAtt> AtWthDay = new List<EmpAtt>();
            var dfg =
                 from a in db.Attendences
                 join at in db.AttendenceRecords on a.Id equals at.Atid into att
                 from at in att.DefaultIfEmpty()
                 //.Where(s => s.Date.Value.Day == day && s.Employe.IsActive == true)
                 .Where(s => s.Date == date && s.Employe.IsActive == true)
                 select new PartialClasses
                 {
                     id = a.Id,
                     name = a.Employe.Name,
                     status = at.Status.Status1,
                     Dname = a.Department.Name,
                     Dsname = a.Designation.Name,
                     time = at.Time,
                     EmpID = a.Employe.Id,
                 };
            ViewBag.AttendecRcrd = dfg;
            //ViewBag.RealDate = ;
            
            if (dfg == null)
            {
                return Json(dfg, JsonRequestBehavior.AllowGet);
            }

            ViewBag.RealDate = date.ToLongDateString();

            return View("_CantactDay", dfg);
        }
        public ActionResult Main()
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo myZone = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            DateTime custDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, myZone);
            //Str.Append(custDateTime.ToString());

            int Month = DateTime.Now.Month;

            //Create List
            List<EmpAtt> empWithDate = new List<EmpAtt>();
            // get emp Name, Id, Date time and order it in ascending order of date
            empWithDate = db.AttendenceRecords.Where(a => a.Date.Value.Month == Month)
                .Select(a =>
                new EmpAtt
                {
                    Id = a.Id,
                    Dt = a.Date,
                    Emp_name = a.Employe.Name,
                    tm = a.Time,
                    status = a.Status.Status1 == null ? "" : a.Status.Status1,
                    depart = a.Employe.Department.Name,
                    desig = a.Employe.Designation.Name,
                    img = a.Employe.Picture == null ? "" : a.Employe.Picture
                }).OrderBy(s => s.Emp_name).ToList();

            return View(empWithDate);


        }
        public ActionResult PervMonth(int mnth)
        {


            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo myZone = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            DateTime custDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, myZone);

            int Month = custDateTime.Month;

            ViewBag.MonthCh = mnth;
            //int mth = Month - mnth;
            //Create List
            List<EmpAtt> empWithDate = new List<EmpAtt>();
            // get emp Name, Id, Date time and order it in ascending order of date
            empWithDate = db.AttendenceRecords.Where(a => a.Date.Value.Month == mnth)
                .Select(a =>
                new EmpAtt
                {
                    Id = a.Id,
                    Dt = a.Date,
                    Emp_name = a.Employe.Name,
                    tm = a.Time,
                    status = a.Status.Status1 == null ? "" : a.Status.Status1,
                    depart = a.Employe.Department.Name,
                    desig = a.Employe.Designation.Name,
                    img = a.Employe.Picture == null ? "" : a.Employe.Picture
                }).OrderBy(s => s.Emp_name).ToList();

            if (empWithDate.Count == 0)
            {
                return Json(empWithDate, JsonRequestBehavior.AllowGet);
            }
            return View("_AttndRecord", empWithDate);


        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Contact()
        {

            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo myZone = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            DateTime custDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, myZone);



            AttendenceRecord attendenceRecord = new AttendenceRecord();
            //ViewBag.TEmp = db.Employes.Where(x => x.IsActive == true).ToList().Count;

            var dt = custDateTime.Date;
            var atn = db.AttendenceRecords.Where(x => x.Date == dt).ToList().Count;
            ViewBag.RealDate = custDateTime.Date;
            if (atn == 0)
            {
                var at = db.Attendences.Where(x => x.IsActive == true).ToList();
                var atdt = db.Attendences.ToList();

                foreach (var item in at)
                {
                    attendenceRecord.Atid = item.Id;
                    attendenceRecord.Sid = null;
                    attendenceRecord.Eid = item.Eid;
                    attendenceRecord.Date = custDateTime.Date;
                    db.AttendenceRecords.Add(attendenceRecord);
                    db.SaveChanges();
                }

                foreach (var item in atdt)
                {
                    item.Date = Convert.ToDateTime(dt);
                    db.Attendences.Attach(item);
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }

            var dfg =
                 from a in db.Attendences
                 join at in db.AttendenceRecords on a.Id equals at.Atid into att
                 from at in att.DefaultIfEmpty()
                 .Where(s => s.Date == dt && s.Employe.IsActive == true)
                     //.DefaultIfEmpty()
                     //join e in db.Employes on at.Eid equals e.Id into es
                     //from e in es.DefaultIfEmpty()
                     //.Where(x => x.IsActive == true)
                     //.Where(s => a.Eid == s.Id)
                     //.DefaultIfEmpty()
                 select new PartialClasses
                 {
                     id = a.Id,
                     //name = e.Name,
                     name = a.Employe.Name,
                     status = at.Status.Status1,
                     Dname = a.Department.Name,
                     Dsname = a.Designation.Name,
                     time = at.Time,
                     EmpID = a.Employe.Id,
                 };


            ViewBag.AttendecRcrd = dfg;

            return View(dfg);
        }
        [HttpPost]
        public ActionResult CompareAtime(int EmpId)
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo myZone = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            DateTime custDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, myZone);



            string result = "";
            try
            {
                AttendenceRecord attendenceRecord = new AttendenceRecord();
                var dt = custDateTime.Date;
                var sts = db.AttendenceRecords.Where(x => x.Eid == EmpId && x.Date == dt && x.Attendence.Time != "0").FirstOrDefault();
                var forDriver = db.AttendenceRecords.Where(x => x.Eid == EmpId && x.Date == dt && x.Attendence.Time == "0").FirstOrDefault();
                var attndTm = db.Attendences.Where(x => x.Eid == EmpId).Select(s => s.Time).FirstOrDefault();

                DateTime CurTime = custDateTime;
                var tm = String.Format("{0:t}", CurTime);
                DateTime tim = Convert.ToDateTime(tm);

                if (sts != null)
                {
                    var Latet = Convert.ToDateTime(String.Format("{0:t}", attndTm)).AddMinutes(20); //Convert.ToDateTime("9:18 AM");
                    var Prsnt = Convert.ToDateTime(String.Format("{0:t}", attndTm)); //Convert.ToDateTime("9:18 AM");
                    var Hlf = Convert.ToDateTime(String.Format("{0:t}", attndTm)).AddHours(3).AddMinutes(20); //Convert.ToDateTime("12:15 PM");
                    var Absent = Convert.ToDateTime(String.Format("{0:t}", attndTm)).AddHours(6).AddMinutes(20); //Convert.ToDateTime("3:10 PM");

                    //Late
                    if (tim > Latet && tim < Hlf)
                    {
                        sts.Sid = 5;
                        sts.Time = tm;
                    }
                    //Present
                    else if (tim < Latet)
                    {
                        sts.Sid = 1;
                        sts.Time = tm;
                    }
                    //Half Day
                    else if (tim > Hlf && tim < Absent)
                    {
                        sts.Sid = 4;
                        sts.Time = tm;
                    }
                    //Absent
                    else if (tim > Absent)
                    {
                        sts.Sid = 2;
                        sts.Time = tm;
                    }
                    db.AttendenceRecords.Attach(sts);
                    db.Entry(sts).State = System.Data.Entity.EntityState.Modified;
                }
                if (forDriver != null)
                {
                    forDriver.Sid = 1;
                    forDriver.Time = tm;

                    db.AttendenceRecords.Attach(forDriver);
                    db.Entry(forDriver).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
                result = "Success";
            }
            catch (Exception)
            {

                throw;
            }

            return View(result);
        }
        public ActionResult Search()
        {


            return View();
        }

    }
}