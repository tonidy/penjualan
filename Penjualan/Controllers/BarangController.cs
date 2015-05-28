using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Penjualan.Models;

namespace Penjualan.Controllers
{
    public class BarangController : Controller
    {
        private PenjualanContainer db = new PenjualanContainer();

        // GET: Barang
        public ActionResult Index()
        {
            return View(db.Barangs.ToList());
        }

        // GET: Barang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barang barang = db.Barangs.Find(id);
            if (barang == null)
            {
                return HttpNotFound();
            }
            return View(barang);
        }

        // GET: Barang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Barang barang)
        {
            if (ModelState.IsValid)
            {
                db.Barangs.Add(barang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barang);
        }

        // GET: Barang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barang barang = db.Barangs.Find(id);
            if (barang == null)
            {
                return HttpNotFound();
            }
            return View(barang);
        }

        // POST: Barang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barang barang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barang);
        }

        // GET: Barang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barang barang = db.Barangs.Find(id);
            if (barang == null)
            {
                return HttpNotFound();
            }
            return View(barang);
        }

        // POST: Barang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barang barang = db.Barangs.Find(id);
            db.Barangs.Remove(barang);
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
