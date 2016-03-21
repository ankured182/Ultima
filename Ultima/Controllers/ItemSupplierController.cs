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
    public class ItemSupplierController : Controller
    {
        private UltimaDb db = new UltimaDb();

        // GET: /ItemSupplier/
        public ActionResult Index()
        {
            var itemsuppliers = db.ItemSuppliers.Include(i => i.ItemPt).Include(i => i.ItemSup);
            return View(itemsuppliers.ToList());
        }

        // GET: /ItemSupplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSupplier itemsupplier = db.ItemSuppliers.Find(id);
            if (itemsupplier == null)
            {
                return HttpNotFound();
            }
            return View(itemsupplier);
        }

        // GET: /ItemSupplier/Create
        public ActionResult Create()
        {
            ViewBag.ItemPtId = new SelectList(db.ItemParts, "Id", "Name");
            ViewBag.ItemSupId = new SelectList(db.Suppliers, "Id", "Name");
            return View();
        }

        // POST: /ItemSupplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ItemPtId,ItemSupId,BuyPrice,SalePrice,ListPrice,ImgUrl,Comments,IsActivated")] ItemSupplier itemsupplier)
        {
            if (ModelState.IsValid)
            {
                db.ItemSuppliers.Add(itemsupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemPtId = new SelectList(db.ItemParts, "Id", "Name", itemsupplier.ItemPtId);
            ViewBag.ItemSupId = new SelectList(db.Suppliers, "Id", "Name", itemsupplier.ItemSupId);
            return View(itemsupplier);
        }

        // GET: /ItemSupplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSupplier itemsupplier = db.ItemSuppliers.Find(id);
            if (itemsupplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemPtId = new SelectList(db.ItemParts, "Id", "Name", itemsupplier.ItemPtId);
            ViewBag.ItemSupId = new SelectList(db.Suppliers, "Id", "Name", itemsupplier.ItemSupId);
            return View(itemsupplier);
        }

        // POST: /ItemSupplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ItemPtId,ItemSupId,BuyPrice,SalePrice,ListPrice,ImgUrl,Comments,IsActivated")] ItemSupplier itemsupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemsupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemPtId = new SelectList(db.ItemParts, "Id", "Name", itemsupplier.ItemPtId);
            ViewBag.ItemSupId = new SelectList(db.Suppliers, "Id", "Name", itemsupplier.ItemSupId);
            return View(itemsupplier);
        }

        // GET: /ItemSupplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSupplier itemsupplier = db.ItemSuppliers.Find(id);
            if (itemsupplier == null)
            {
                return HttpNotFound();
            }
            return View(itemsupplier);
        }

        // POST: /ItemSupplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSupplier itemsupplier = db.ItemSuppliers.Find(id);
            db.ItemSuppliers.Remove(itemsupplier);
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
