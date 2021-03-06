﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeWork1.Models;
using HomeWork1.Services;
using X.PagedList;

namespace HomeWork1.Controllers
{
    public class 客戶銀行資訊Controller : Controller
    {
        I客戶資料Service _客戶資料Service;
        I客戶銀行資訊Service _客戶銀行資訊Service;

        public 客戶銀行資訊Controller(I客戶資料Service 客戶資料Service, I客戶銀行資訊Service 客戶銀行資訊Service)
        {
            _客戶資料Service = 客戶資料Service;
            _客戶銀行資訊Service = 客戶銀行資訊Service;
        }

        // GET: 客戶銀行資訊
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var 客戶銀行資訊s = _客戶銀行資訊Service.Reads();
            var result = 客戶銀行資訊s.OrderBy(x => x.客戶Id).ToPagedList(page, pageSize);
            return View(result);

            //return View(客戶銀行資訊s.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult IndexAjax(int page = 1, int pageSize = 5)
        {
            var 客戶銀行資訊s = _客戶銀行資訊Service.Reads();

            var result = 客戶銀行資訊s.OrderBy(x => x.客戶Id).ToPagedList(page, pageSize);
            return View(result);
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = _客戶銀行資訊Service.Read(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(_客戶資料Service.Reads(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                _客戶銀行資訊Service.Create(客戶銀行資訊);
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(_客戶資料Service.Reads(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = _客戶銀行資訊Service.Read(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(_客戶資料Service.Reads(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                _客戶銀行資訊Service.Update(客戶銀行資訊);
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(_客戶資料Service.Reads(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = _客戶銀行資訊Service.Read(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _客戶銀行資訊Service.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        public ActionResult GetTime()
        {
            return Content(DateTime.Now.ToShortTimeString());
        }

    }
}
