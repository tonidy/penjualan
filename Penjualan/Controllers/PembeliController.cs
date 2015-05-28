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
    public class PembeliController : Controller
    {
        private PenjualanContainer db = new PenjualanContainer();

        // GET: Pembeli
        public ActionResult Index()
        {
            return View(db.Pembelis.Include(x => x.KategoriPembeli).ToList());
        }

        // GET: Pembeli/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pembeli pembeli = db.Pembelis.Find(id);
            if (pembeli == null)
            {
                return HttpNotFound();
            }
            return View(pembeli);
        }

        // GET: Pembeli/Create
        public ActionResult Create()
        {
            var list = db.KategoriPembelis.ToList().Select(x=> new SelectListItem{
            Text=x.Nama,Value=x.Id.ToString()});
            var vm = new CreateViewModel { 
                ListKategoriPembeli = list.ToList()
            };

            return View(vm);
        }

        // POST: Pembeli/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel cvpembeli)
        {
            var kategori = db.KategoriPembelis.SingleOrDefault(x => x.Id == cvpembeli.KategoriPembeli);
            var pembeli = new Pembeli
            {
                Nama = cvpembeli.Nama,
                JenisKelamin = cvpembeli.IsFemale ? "P" : "L",
                KategoriPembeli = kategori,
                TTL = cvpembeli.TTL
            };
            if (ModelState.IsValid)
            {
                db.Pembelis.Add(pembeli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cvpembeli);
        }

        // GET: Pembeli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pembeli pembeli = db.Pembelis.Find(id);
            if (pembeli == null)
            {
                return HttpNotFound();
            }
            return View(pembeli);
        }

        // POST: Pembeli/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pembeli pembeli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pembeli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pembeli);
        }

        // GET: Pembeli/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pembeli pembeli = db.Pembelis.Find(id);
            if (pembeli == null)
            {
                return HttpNotFound();
            }
            return View(pembeli);
        }

        // POST: Pembeli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pembeli pembeli = db.Pembelis.Find(id);
            db.Pembelis.Remove(pembeli);
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
