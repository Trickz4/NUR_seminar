using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NUR.DAL;
using NUR.Models;

namespace NUR.Controllers
{
    public class StrojnasController : Controller
    {
        private NurContext db = new NurContext();

        // GET: Strojnas
        public ActionResult Index()
        {
            //return View(db.Strojnas.ToList());

            ////var test = db.Programskas.Include(x => x.Strojna) // povuce Strojna tablicu
            ////    .Include(y => y.Strojna.Prostorija) // povuce Prostoriju tablica preko Strojna tablica
            ////    .ToList();

            ////return View(test);

            var test = db.Strojnas.Include(x => x.Programska) // povuce Programska tablicu
                .Include(y => y.Prostorija)
                .OrderBy(t => t.Ime)// povuce Prostorija tablicu
                .ToList();



            return View(test);
        }

        // GET: Strojnas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strojna strojna = db.Strojnas.Find(id);
            if (strojna == null)
            {
                return HttpNotFound();
            }
            return View(strojna);
        }

        // GET: Strojnas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Strojnas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Kategorija,ProgramskaId,ProstorijaId")] Strojna strojna)
        {
            if (ModelState.IsValid)
            {
                var testiranje = db.Strojnas.Add(strojna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(strojna);

            //if (ModelState.IsValid)
            //{
            //    var testiranje = db.Strojnas.Include(x => x.Prostorija);

            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(strojna);
        }

        // GET: Strojnas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strojna strojna = db.Strojnas.Find(id);
            if (strojna == null)
            {
                return HttpNotFound();
            }
            return View(strojna);
        }

        // POST: Strojnas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Kategorija")] Strojna strojna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strojna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(strojna);
        }

        // GET: Strojnas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strojna strojna = db.Strojnas.Find(id);
            if (strojna == null)
            {
                return HttpNotFound();
            }
            return View(strojna);
        }

        // POST: Strojnas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Strojna strojna = db.Strojnas.Find(id);
            db.Strojnas.Remove(strojna);
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