﻿using System;
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
    public class OrderController : Controller
    {
        private PenjualanContainer db = new PenjualanContainer();

        // GET: Order
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var barangs = db.Barangs.Select(x => new SelectListItem { Text = x.Nama, Value = x.Id.ToString() }).ToList();
            var viewModel = new OrderCreateViewModel
            {
                BarangDropDownList = barangs
            };
            return View(viewModel);
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreateViewModel viewModel)
        {
            var order = new Order
            {
                Total = viewModel.Total
            };
            var barangList = viewModel.BarangList;
            db.Database.Log = Logger;

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                //db.SaveChanges();

                foreach (var item in barangList)
                {
                    var barang = db.Barangs.SingleOrDefault(x => x.Id.ToString() == item);
                    var orderDetail = new OrderDetail
                    {
                        Barang = barang,
                        Order = order
                    };
                    db.OrderDetails.Add(orderDetail);
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(order);
        }

        private void Logger(string message)
        {
            Debug.WriteLine(message);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
