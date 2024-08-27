using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyAspMvc.DAL;
using MyAspMvc.Models;

namespace MyAspMvc.Controllers
{
    public class OrderMasterController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: OrderMaster
        public ActionResult Index()
        {
            return View(db.OrderMasters.ToList());
        }

        // GET: OrderMaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster orderMaster = db.OrderMasters.Find(id);
            if (orderMaster == null)
            {
                return HttpNotFound();
            }
            return View(orderMaster);
        }

        public JsonResult OrderDetails(int id)
        {
            var orderDetails = db.OrderDetails.Where(o => o.OrderMasterId == id).ToList();

            var orderInfo = orderDetails
                    .Select(o => new {
                        id = o.OrderMasterId,
                        bookId = o.BookId,
                        bookName = db.Books.FirstOrDefault(p => p.BookId == o.BookId)?.BookName,
                        quantity = o.Quantity.ToString(),
                        unitPrice = o.UnitPrice.ToString(),
                        totalPrice = o.Quantity * o.UnitPrice
                    });
            return Json(orderInfo, JsonRequestBehavior.AllowGet);
        }


        // GET: OrderMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderMaster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderMasterId,OrderDate,Note,Image")] OrderMaster orderMaster)
        {
            if (ModelState.IsValid)
            {
                db.OrderMasters.Add(orderMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderMaster);
        }

        // GET: OrderMaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster orderMaster = db.OrderMasters.Find(id);
            if (orderMaster == null)
            {
                return HttpNotFound();
            }
            return View(orderMaster);
        }

        // POST: OrderMaster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderMasterId,OrderDate,Note,Image")] OrderMaster orderMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderMaster);
        }

        // GET: OrderMaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster orderMaster = db.OrderMasters.Find(id);
            if (orderMaster == null)
            {
                return HttpNotFound();
            }
            return View(orderMaster);
        }

        // POST: OrderMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderMaster orderMaster = db.OrderMasters.Find(id);
            db.OrderMasters.Remove(orderMaster);
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
