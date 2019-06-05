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
using HomeWork1.Utils;

namespace HomeWork1.Controllers
{
    public class 客戶資料Controller : Controller
    {
        Iv_客戶分類Service _v_客戶分類;
        I客戶資料Service _客戶資料Service;
        I客戶聯絡人Service _客戶聯絡人Service;

        public 客戶資料Controller(Iv_客戶分類Service v_客戶分類, I客戶資料Service 客戶資料Service, I客戶聯絡人Service 客戶聯絡人Service)
        {
            _v_客戶分類 = v_客戶分類;
            _客戶資料Service = 客戶資料Service;
            _客戶聯絡人Service = 客戶聯絡人Service;
        }

        // GET: 客戶資料
        public ActionResult Index(String 客戶分類)
        {
            List<v_客戶分類> selectOptions = _v_客戶分類.Reads().OrderBy(a => a.客戶分類).ToList();
            selectOptions.Add(new v_客戶分類() { Id = "" , 客戶分類 = "" });

            ViewBag.客戶分類 = new SelectList(selectOptions, "客戶分類", "客戶分類", 客戶分類);

            var 客戶資料 = _客戶資料Service.Reads();
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
            客戶資料 客戶資料 = _客戶資料Service.Read(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            ViewBag.客戶聯絡人s = _客戶聯絡人Service.Reads().Where(a => a.客戶Id == id).ToList();

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
                客戶資料.密碼 = CryptographyUtils.SHA256Cryp(客戶資料.密碼);
                _客戶資料Service.Create(客戶資料);
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        public ActionResult CreateAjax()
        {
            客戶資料 客戶資料 = new 客戶資料();
            客戶資料.電話 = "1111-123456";
            return View(客戶資料);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAjax(客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                客戶資料.密碼 = CryptographyUtils.SHA256Cryp(客戶資料.密碼);
                _客戶資料Service.Create(客戶資料);
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
            客戶資料 客戶資料 = _客戶資料Service.Read(id.Value);
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
        public ActionResult Edit([Bind(Exclude = "密碼")]客戶資料 客戶資料)
        {
            客戶資料 tmp = _客戶資料Service.Reads().Where(a => a.Id == 客戶資料.Id).FirstOrDefault();
            if (null != tmp)
            {
                客戶資料.密碼 = tmp.密碼;
                ModelState.Remove("密碼");
                if (ModelState.IsValid)
                {
                    _客戶資料Service.Update(客戶資料.Id, 客戶資料);
                    return RedirectToAction("Index");
                }
            }
            return View(客戶資料);
        }

        public ActionResult UpdatePwd(String Id)
        {
            //如果有需要再確認密碼就可以傳回去 , _客戶資料Repository.Where(a => a.Id.Equals(Id))
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePwd(int Id, String pwd)
        {
            if (!String.IsNullOrEmpty(pwd))
            {
                客戶資料 entity = _客戶資料Service.Read(Id);
                entity.密碼 = CryptographyUtils.SHA256Cryp(pwd);
                _客戶資料Service.Update(Id, entity);
                return RedirectToAction("Index");
            }
            else
            {

            }
            return View();
        }

        [HttpPost]
        public ActionResult Edits([Bind(Exclude = "客戶資料")]客戶聯絡人[] 客戶聯絡人s)
        {
            if (null != 客戶聯絡人s && 客戶聯絡人s.Count() > 0)
            {
                if (ModelState.IsValid)
                {
                    foreach (客戶聯絡人 s in 客戶聯絡人s)
                    {
                        //欄位不多就先這樣
                        客戶聯絡人 m = _客戶聯絡人Service.Reads().Where(a => a.Id == s.Id).FirstOrDefault();
                        m.職稱 = s.職稱;
                        m.手機 = s.手機;
                        m.電話 = s.電話;
                        _客戶聯絡人Service.Update(s.Id, m);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var model in ModelState)
                    {
                        if (!ModelState.IsValidField(model.Key))
                        {
                            foreach (var error in model.Value.Errors)
                            {
                                String test = error.ErrorMessage;
                            }
                        }
                    }
                }
                return RedirectToAction("Details", new { id = 客戶聯絡人s[0].客戶Id });
            }
            return View();
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            客戶資料 客戶資料 = _客戶資料Service.Read(id.Value);
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
            _客戶資料Service.Delete(id);
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
