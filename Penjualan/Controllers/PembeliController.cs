using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Penjualan.Models;
using System.Diagnostics;

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
            return View();
        }

        // POST: Pembeli/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pembeli pembeli)
        {

            if (ModelState.IsValid)
            {
                db.Pembelis.Add(pembeli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pembeli);
        }


        // GET: Pembeli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pembeli pembeli = db.Pembelis.Find(id);
			var KategoriPembeliList = db.KategoriPembelis.Select(x => new SelectListItem
			{
				Text = x.Nama,
				Value = x.Id.ToString()
			});

			var ViewModel = new PembeliEditViewModels
			{
				Id = pembeli.Id,
				Nama=pembeli.Nama,
				JenisKelamin= pembeli.JenisKelamin,
				IsFemale = pembeli.JenisKelamin == "P" ? true : false,
				TTL=pembeli.TTL,
				KategoriPembeli=pembeli.KategoriPembeli.Id,
				KategoriPembeliList=KategoriPembeliList.ToList()
			};
			
            if (pembeli == null)
            {
                return HttpNotFound();
            }
			return View(ViewModel);
        }

        // POST: Pembeli/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		//public ActionResult Edit(Pembeli pembeli)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		db.Entry(pembeli).State = EntityState.Modified;
		//		db.SaveChanges();
		//		return RedirectToAction("Index");
		//	}
		//	return View(pembeli);
		//}

		public ActionResult Edit(PembeliEditViewModels ViewModels)
		{
			var Kategori=db.KategoriPembelis.SingleOrDefault(x=>x.Id==ViewModels.KategoriPembeli);
			//var pembeli = new Pembeli
			//{
			//	Id = ViewModels.Id,
			//	Nama = ViewModels.Nama,
			//	JenisKelamin = ViewModels.IsFemale ? "P" : "L",
			//	TTL = ViewModels.TTL,
			//	KategoriPembeli= Kategori
			//};
			//pembeli.KategoriPembeli = new KategoriPembeli();
			//pembeli.KategoriPembeli.Id = Kategori.Id;

			var pembeli = db.Pembelis.SingleOrDefault(x => x.Id == ViewModels.Id);
			pembeli.Nama = ViewModels.Nama;
			pembeli.JenisKelamin = ViewModels.IsFemale ? "P" : "L";
			pembeli.TTL = ViewModels.TTL;
			pembeli.KategoriPembeli = Kategori;

			if (ModelState.IsValid)
			{
				db.Database.Log = Logger;
				//db.Pembelis.Attach(pembeli);
				db.Entry(pembeli).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(ViewModels);
		}

		private void Logger(string logString)
		{
			Debug.WriteLine(logString);
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
