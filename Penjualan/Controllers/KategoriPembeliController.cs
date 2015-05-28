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
    public class KategoriPembeliController : Controller
    {
        private PenjualanContainer db = new PenjualanContainer();

        // GET: KategoriPembeli
        public ActionResult Index()
        {
            return View(db.KategoriPembelis.ToList());
        }

        // GET: KategoriPembeli/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriPembeli kategoriPembeli = db.KategoriPembelis.Find(id);
            if (kategoriPembeli == null)
            {
                return HttpNotFound();
            }
            return View(kategoriPembeli);
        }

        // GET: KategoriPembeli/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KategoriPembeli/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KategoriPembeli kategoriPembeli)
        {
            if (ModelState.IsValid)
            {
                db.KategoriPembelis.Add(kategoriPembeli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoriPembeli);
        }

        // GET: KategoriPembeli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriPembeli kategoriPembeli = db.KategoriPembelis.Find(id);
            if (kategoriPembeli == null)
            {
                return HttpNotFound();
            }
            return View(kategoriPembeli);
        }

        // POST: KategoriPembeli/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KategoriPembeli kategoriPembeli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriPembeli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoriPembeli);
        }

        // GET: KategoriPembeli/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriPembeli kategoriPembeli = db.KategoriPembelis.Find(id);
            if (kategoriPembeli == null)
            {
                return HttpNotFound();
            }
            return View(kategoriPembeli);
        }

        // POST: KategoriPembeli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategoriPembeli kategoriPembeli = db.KategoriPembelis.Find(id);
            db.KategoriPembelis.Remove(kategoriPembeli);
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
