using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Memberships.Entities;
using Memberships.Models;

namespace Memberships.Areas.Admin.Controllers
{
    public class ItemTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ItemType
        public ActionResult Index()
        {
            return View(db.ItemTypes.ToList());
        }

        // GET: Admin/ItemType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType itemType = db.ItemTypes.Find(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }
            return View(itemType);
        }

        // GET: Admin/ItemType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ItemType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                db.ItemTypes.Add(itemType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemType);
        }

        // GET: Admin/ItemType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType itemType = db.ItemTypes.Find(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }
            return View(itemType);
        }

        // POST: Admin/ItemType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemType);
        }

        // GET: Admin/ItemType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType itemType = db.ItemTypes.Find(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }
            return View(itemType);
        }

        // POST: Admin/ItemType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemType itemType = db.ItemTypes.Find(id);
            db.ItemTypes.Remove(itemType);
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
