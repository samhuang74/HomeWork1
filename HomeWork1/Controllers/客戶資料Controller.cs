using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeWork1.Models;

namespace HomeWork1.Controllers
{
    public class 客戶資料Controller : Controller
    {
        I客戶資料Repository _客戶資料Repository;
        Iv_客戶分類Repository _v客戶分類Repository;

        public 客戶資料Controller()
        {
            _客戶資料Repository = RepositoryHelper.Get客戶資料Repository();
            _v客戶分類Repository = RepositoryHelper.Getv_客戶分類Repository();
        }

        // GET: 客戶資料
        public ActionResult Index(String 客戶分類)
        {
            ViewBag.客戶分類 = new SelectList(_v客戶分類Repository.All().OrderBy(a => a.客戶分類), "客戶分類", "客戶分類", 客戶分類);

            var 客戶資料 = _客戶資料Repository.ReadAllNotDelete();
            if (!String.IsNullOrEmpty(客戶分類))
            {
                客戶資料 = 客戶資料.Where(a => a.客戶分類.Equals(客戶分類));
            }

            return View(客戶資料.ToList());
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = _客戶資料Repository.ReadNotDelete(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            客戶資料 客戶資料 = new 客戶資料();
            客戶資料.電話 = "1111-123456";
            return View(客戶資料);
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                _客戶資料Repository.Add(客戶資料);
                _客戶資料Repository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = _客戶資料Repository.ReadNotDelete(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                _客戶資料Repository.UnitOfWork.Context.Entry(客戶資料).State = EntityState.Modified;
                _客戶資料Repository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = _客戶資料Repository.ReadNotDelete(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _客戶資料Repository.UpdateToDelete(id);
            return RedirectToAction("Index");
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
