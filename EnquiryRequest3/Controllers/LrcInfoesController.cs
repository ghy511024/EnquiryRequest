﻿using System;
using System.Collections.Generic;
//using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnquiryRequest3.Models;

namespace EnquiryRequest3.Controllers
{
    public class LrcInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LrcInfoes
        public ActionResult Index()
        {
            return View(db.LrcInfoes.ToList());
        }

        // GET: LrcInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LrcInfo lrcInfo = db.LrcInfoes.Find(id);
            if (lrcInfo == null)
            {
                return HttpNotFound();
            }
            return View(lrcInfo);
        }

        // GET: LrcInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LrcInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LrcInfoId,Name,Area,CompanyNumber,CharityNumber,Address1,Address2,Address3,PostCode,Phone,Email,Website,PaymentTerms,BankAccountName,BankAccountSortCode,BankAccountNumber,InformationRequested,Declaration")] LrcInfo lrcInfo)
        {
            if (ModelState.IsValid)
            {
                db.LrcInfoes.Add(lrcInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lrcInfo);
        }

        // GET: LrcInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LrcInfo lrcInfo = db.LrcInfoes.Find(id);
            if (lrcInfo == null)
            {
                return HttpNotFound();
            }
            return View(lrcInfo);
        }

        // POST: LrcInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LrcInfoId,Name,Area,CompanyNumber,CharityNumber,Address1,Address2,Address3,PostCode,Phone,Email,Website,PaymentTerms,BankAccountName,BankAccountSortCode,BankAccountNumber,InformationRequested,Declaration, RowVersion")] LrcInfo lrcInfo)
        {
            if (!ModelState.IsValid) return View(lrcInfo);
            try
            {
                db.Entry(lrcInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                ViewBag.Message = "Sorry, couldn't update due to a concurrency issue <br />Please try again";
                return View(lrcInfo);
            }

        }

        // GET: LrcInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LrcInfo lrcInfo = db.LrcInfoes.Find(id);
            if (lrcInfo == null)
            {
                return HttpNotFound();
            }
            return View(lrcInfo);
        }

        // POST: LrcInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                LrcInfo lrcInfo = db.LrcInfoes.Find(id);
                db.LrcInfoes.Remove(lrcInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                ViewBag.Message = "Sorry, couldn't delete due to a concurrency issue <br />Please try again";
                return RedirectToAction("Delete");
            }
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
