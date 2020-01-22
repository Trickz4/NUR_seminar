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
    public class ProstorijasController : Controller
    {
        private NurContext db = new NurContext();

        // GET: Prostorijas
        public ActionResult Index()
        {
            return View(db.Prostorijas.ToList());
        }

        // GET: Prostorijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Prostorija prostorija = db.Prostorijas.Find(id);

            //var prostorija = db.Strojnas.Include(x => x.Programska)
            //    .Include(y => y.Prostorija)
            //    .Where(d => d.Prostorija.ID == id)
            //    .FirstOrDefault();

            var prostorija = db.Strojnas
                .Where(d => d.Prostorija.ID == id)
                .OrderBy(t => t.Ime)
                .Include(x => x.Programska)
                .Include(y => y.Prostorija)
                .ToList();

            if (prostorija == null)
            {
                return HttpNotFound();
            }
            return View(prostorija);
        }

        // GET: Prostorijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prostorijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Kategorija,Broj")] Prostorija prostorija)
        {
            if (ModelState.IsValid)
            {
                db.Prostorijas.Add(prostorija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prostorija);
        }

        // GET: Prostorijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prostorija prostorija = db.Prostorijas.Find(id);
            if (prostorija == null)
            {
                return HttpNotFound();
            }
            return View(prostorija);
        }

        // POST: Prostorijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Kategorija,Broj")] Prostorija prostorija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prostorija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prostorija);
        }

        // GET: Prostorijas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prostorija prostorija = db.Prostorijas.Find(id);
            if (prostorija == null)
            {
                return HttpNotFound();
            }
            return View(prostorija);
        }

        // POST: Prostorijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prostorija prostorija = db.Prostorijas.Find(id);
            db.Prostorijas.Remove(prostorija);
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