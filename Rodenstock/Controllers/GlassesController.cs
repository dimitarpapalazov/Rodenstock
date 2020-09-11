using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rodenstock.Models;

namespace Rodenstock.Controllers
{
    public class GlassesController : Controller
    {
        private GlassesContext db = new GlassesContext();

        // GET: Glasses
        public ActionResult Index()
        {
            return View(db.Glasses.ToList());
        }

        // GET: Glasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glasses glasses = db.Glasses.Find(id);
            if (glasses == null)
            {
                return HttpNotFound();
            }
            return View(glasses);
        }

        // GET: Glasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Glasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Brand,Color,Material,Sex,Price,ImageUrl")] Glasses glasses)
        {
            if (ModelState.IsValid)
            {
                db.Glasses.Add(glasses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glasses);
        }

        // GET: Glasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glasses glasses = db.Glasses.Find(id);
            if (glasses == null)
            {
                return HttpNotFound();
            }
            return View(glasses);
        }

        // POST: Glasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,Color,Material,Sex,Price,ImageUrl")] Glasses glasses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glasses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glasses);
        }

        // GET: Glasses/Delete/5
        public ActionResult Delete(int id)
        {
            Glasses glasses = db.Glasses.Find(id);
            db.Glasses.Remove(glasses);
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
