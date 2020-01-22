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
using NUR_seminar.Models;

namespace NUR.Controllers
{
    public class ProgramskasController : Controller
    {
        private NurContext db = new NurContext();

        // GET: Programskas
        public ActionResult Index()
        {

            List<Programska> programskalista = db.Programskas.ToList();

            var test = db.Programskas.ToList();
            return View(db.Programskas.ToList());



            //var test = db.Programskas.ToList();
            ////return View(db.Programskas.ToList());
            //var events = from r in db.Programskas
            //             where r.Ime == "asd"
            //             select r; 

            //var events2 = from r in db.Prostorijas
            //              where r.Broj == 1
            //              select r; 

            ////var model = new Events1i2 { Currencies = currencies.ToArray(), CurrentWeather = weather };
            //var model = new Events3 { Asd = events.ToArray(), Asd1 = events2.ToArray() };
            //return View(model);
        }

        // GET: Programskas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programska programska = db.Programskas.Find(id);
            if (programska == null)
            {
                return HttpNotFound();
            }
            return View(programska);
        }

        // GET: Programskas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programskas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Kategorija")] Programska programska)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Programskas.Add(programska);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(programska);

            // moj kod
            var events = from r in db.Programskas
                         where r.Ime == "asd"
                         select r; 

            return View(events);
        }

        // GET: Programskas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programska programska = db.Programskas.Find(id);
            if (programska == null)
            {
                return HttpNotFound();
            }
            return View(programska);
        }

        // POST: Programskas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Kategorija")] Programska programska)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programska).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programska);
        }

        // GET: Programskas/Delete/5
        //[Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programska programska = db.Programskas.Find(id);
            if (programska == null)
            {
                return HttpNotFound();
            }
            return View(programska);
        }

        // POST: Programskas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programska programska = db.Programskas.Find(id);
            db.Programskas.Remove(programska);
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