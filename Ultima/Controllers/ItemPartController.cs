using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ultima.Models.SpareParts;
using Ultima.DataLayer;

namespace Ultima.Controllers
{
    public class ItemPartController : Controller
    {
        private UltimaDb db = new UltimaDb();

        // GET: /ItemPart/
        public ActionResult Index()
        {
            return View(db.ItemParts.ToList());
        }

        // GET: /ItemPart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPart itempart = db.ItemParts.Find(id);
            if (itempart == null)
            {
                return HttpNotFound();
            }
            return View(itempart);
        }

        // GET: /ItemPart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ItemPart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Dscrp")] ItemPart itempart)
        {
            if (ModelState.IsValid)
            {
                db.ItemParts.Add(itempart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itempart);
        }

        // GET: /ItemPart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPart itempart = db.ItemParts.Find(id);
            if (itempart == null)
            {
                return HttpNotFound();
            }
            return View(itempart);
        }

        // POST: /ItemPart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Dscrp")] ItemPart itempart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itempart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itempart);
        }

        // GET: /ItemPart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPart itempart = db.ItemParts.Find(id);
            if (itempart == null)
            {
                return HttpNotFound();
            }
            return View(itempart);
        }

        // POST: /ItemPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemPart itempart = db.ItemParts.Find(id);
            db.ItemParts.Remove(itempart);
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
