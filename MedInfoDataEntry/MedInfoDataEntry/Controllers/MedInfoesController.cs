using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedInfoDataEntry.Models;

namespace MedInfoDataEntry.Controllers
{
    public class MedInfoesController : Controller
    {
        private MedInfoDBEntities db = new MedInfoDBEntities();

        // GET: MedInfoes
        public ActionResult Index(string currentFilter, string SearchString)
        {
            int id = Convert.ToInt32(SearchString);
            ViewBag.CurrentFilter = SearchString;

            var info = from inf in db.MedInfoes
                       select inf;

            if (!String.IsNullOrEmpty(SearchString))
            {
                info = info.Where(i => i.id == id);
            }

            return View(info);

            //return View(db.MedInfoes.ToList());
        }  

        //[HttpPost]
        //[Route("MedInfoes/Search1")]
        //public ActionResult Search1(string searchId)
        //{
        //    if (!String.IsNullOrEmpty(searchId))
        //    {
        //        int id = Convert.ToInt32(searchId);
        //        var info = from infoSearh in db.MedInfoes select infoSearh;
        //        {
        //            info = info.Where(inf => inf.id == id);
        //        }

        //        return View(info.ToList());
        //    }
        //    else
        //        return View(db.MedInfoes.ToList());
        //}

        // GET: MedInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedInfo medInfo = db.MedInfoes.Find(id);
            if (medInfo == null)
            {
                return HttpNotFound();
            }
            return View(medInfo);
        }

        // GET: MedInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,category1,category2,category3,category4,category5,MedInfo1,Approved,HitCounter")] MedInfo medInfo)
        {
            if (ModelState.IsValid)
            {
                db.MedInfoes.Add(medInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medInfo);
        }

        // GET: MedInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedInfo medInfo = db.MedInfoes.Find(id);
            if (medInfo == null)
            {
                return HttpNotFound();
            }
            return View(medInfo);
        }

        // POST: MedInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,category1,category2,category3,category4,category5,MedInfo1,Approved,HitCounter")] MedInfo medInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medInfo);
        }

        // GET: MedInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedInfo medInfo = db.MedInfoes.Find(id);
            if (medInfo == null)
            {
                return HttpNotFound();
            }
            return View(medInfo);
        }

        // POST: MedInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedInfo medInfo = db.MedInfoes.Find(id);
            db.MedInfoes.Remove(medInfo);
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
