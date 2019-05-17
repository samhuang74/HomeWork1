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
    public class 客戶聯絡人Controller : Controller
    {
        I客戶聯絡人Repository _客戶聯絡人Repository;
        I客戶資料Repository _客戶資料Repository;

        public 客戶聯絡人Controller()
        {
            _客戶聯絡人Repository = RepositoryHelper.Get客戶聯絡人Repository();
            _客戶資料Repository = RepositoryHelper.Get客戶資料Repository();
        }


        public ActionResult Index()
        {
            var 客戶聯絡人 = _客戶聯絡人Repository.ReadAllNotDelete();
            return View(客戶聯絡人.ToList());
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶聯絡人 客戶聯絡人 = _客戶聯絡人Repository.ReadNotDelete(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(_客戶資料Repository.ReadAllNotDelete(), "Id", "客戶名稱");
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
                if (IsEmail重複(客戶聯絡人.客戶Id, null, 客戶聯絡人.Email))
                {
                    _客戶聯絡人Repository.Add(客戶聯絡人);
                    _客戶聯絡人Repository.UnitOfWork.Commit();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", 客戶聯絡人.客戶Id + " Email重複");
                }
            }

            ViewBag.客戶Id = new SelectList(_客戶資料Repository.ReadAllNotDelete(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        private Boolean IsEmail重複(int 客戶Id, int? 客戶聯絡人Id, String 客戶聯絡人Email)
        {
            Boolean re = false;

            if (!String.IsNullOrEmpty(客戶聯絡人Email))
            {
                var 客戶聯絡人 = _客戶聯絡人Repository.ReadAllNotDelete().Where(a => a.客戶Id == 客戶Id && a.Email.Equals(客戶聯絡人Email));

                if (null != 客戶聯絡人Id)
                {
                    客戶聯絡人 = 客戶聯絡人.Where(a => a.Id != 客戶聯絡人Id);
                }

                if (客戶聯絡人.Count() > 0)
                {
                    re = true;
                }
            }

            return re;
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = _客戶聯絡人Repository.ReadNotDelete(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(_客戶資料Repository.ReadAllNotDelete(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
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
                if (IsEmail重複(客戶聯絡人.客戶Id, null, 客戶聯絡人.Email))
                {
                    _客戶聯絡人Repository.UnitOfWork.Context.Entry(客戶聯絡人).State = EntityState.Modified;
                    _客戶聯絡人Repository.UnitOfWork.Commit();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", 客戶聯絡人.客戶Id + " Email重複");
                }
            }

            ViewBag.客戶Id = new SelectList(_客戶聯絡人Repository.ReadAllNotDelete(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = _客戶聯絡人Repository.ReadNotDelete(id.Value);
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
            客戶聯絡人 客戶聯絡人 = _客戶聯絡人Repository.ReadNotDelete(id);
            _客戶聯絡人Repository.UnitOfWork.Commit();
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
