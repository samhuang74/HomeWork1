using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeWork1.Models;
using HomeWork1.Services;

namespace HomeWork1.Controllers
{
    public class 客戶聯絡人Controller : Controller
    {
        I客戶聯絡人Service _客戶聯絡人Service;
        I客戶資料Service _客戶資料Service;

        public 客戶聯絡人Controller(I客戶聯絡人Service 客戶聯絡人Service, I客戶資料Service 客戶資料Service)
        {
            _客戶聯絡人Service = 客戶聯絡人Service;
            _客戶資料Service = 客戶資料Service;
        }


        public ActionResult Index(String 職稱查詢條件)
        {
            var 客戶聯絡人 = _客戶聯絡人Service.Reads();
            if (!String.IsNullOrEmpty(職稱查詢條件))
            {
                ViewBag.職稱查詢條件 = 職稱查詢條件;
                客戶聯絡人 = 客戶聯絡人.Where(a => a.職稱.Equals(職稱查詢條件));
            }

            return View(客戶聯絡人.ToList());
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶聯絡人 客戶聯絡人 = _客戶聯絡人Service.Read(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(_客戶資料Service.Reads(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {                
                客戶聯絡人 Email重複 = _客戶聯絡人Service.IsEmail重複(客戶聯絡人.客戶Id, null, 客戶聯絡人.Email);
                if (null == Email重複)
                {
                    _客戶聯絡人Service.Update(客戶聯絡人.Id, 客戶聯絡人);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", Email重複.姓名 + " Email重複");
                }
            }

            ViewBag.客戶Id = new SelectList(_客戶資料Service.Reads(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = _客戶聯絡人Service.Read(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(_客戶資料Service.Reads(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                客戶聯絡人 Email重複 = _客戶聯絡人Service.IsEmail重複(客戶聯絡人.客戶Id, null, 客戶聯絡人.Email);
                if (null == Email重複)
                {
                    _客戶聯絡人Service.Update(客戶聯絡人.Id, 客戶聯絡人);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", Email重複.客戶Id + " Email重複");
                }
            }

            ViewBag.客戶Id = new SelectList(_客戶資料Service.Reads(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = _客戶聯絡人Service.Read(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _客戶聯絡人Service.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult ListBy客戶Id(int 客戶Id)
        {
            return View(_客戶聯絡人Service.Reads().Where(a => a.客戶Id == 客戶Id).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            base.Dispose(disposing);
        }
    }
}
