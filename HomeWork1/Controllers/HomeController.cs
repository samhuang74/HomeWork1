using HomeWork1.Models;
using HomeWork1.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace HomeWork1.Controllers
{

    //資料庫下載: https://drive.google.com/open?id=0B9TSNtgzYzPTSGR5TEc4TjcwZmM
    //請使用 "客戶資料" 這個資料庫做開發(如附件檔案)
    //請實作出「客戶資料管理」、「客戶聯絡人管理」與「客戶銀行帳戶管理」等簡易 CRUD 功能(盡量做各種功能出來)
    //主選單要有連結可以直接連到三個主要功能的列表頁。
    //實作一個清單頁面，顯示欄位有「客戶名稱、聯絡人數量、銀行帳戶數量」共三個欄位，此功能要在資料庫中建立一個檢視表，並且匯入 EDMX。
    //實作一個「自訂輸入驗證屬性」可驗證「手機」的電話格式必須為 "\d{4}-\d{6}" 的格式(e.g. 0911-111111 )
    //Email 驗證
    //對於 Create 與 Edit 表單要套用欄位驗證(必填、Email格式、欄位長度限制等驗證)
    //使用 Repository Pattern 管理所有新刪查改(CRUD)等功能
    //資料篩選的邏輯要寫在 Repository 的類別裡面
    //刪除資料功能不能真的刪除資料庫中的資料，必須修改資料庫，加上一個「是否已刪除」欄位，資料庫中的該欄位為 bit 類型，0 代表未刪除，1 代表已刪除，且列表頁不得顯示已刪除的資料。
    //修改所有的「刪除」邏輯，所有資料都不能真正被刪除，資料庫中也要新增「是否已刪除」欄位(欄位要設定 bit 型態)
    //實作「客戶聯絡人」時，同一個客戶下的聯絡人，其 Email 不能重複。 create & edit 
    //在「客戶聯絡人列表」頁面新增篩選功能，可以用「職稱」欄位進行資料篩選
    //在列表頁要實作「搜尋」功能
    //修改「客戶資料」表格，新增「客戶分類」欄位，可設定特定選項的分類
    //在「客戶資料列表」頁面新增篩選功能，可以用「客戶分類」欄位進行資料篩選(下拉選單)

    //TODO:修改「客戶資料列表」與「客戶聯絡人列表」頁面，設定讓每個欄位都能進行排序(可升冪、可降冪排序)

    //TODO:如果可以的話，透過 JavaScript 實作一些 AJAX 操作，後端 MVC 使用 JsonResult 進行回應
    //TODO:使用 ClosedXML 這個 NuGet 套件實作資料匯出功能，每個清單頁上都要有可以匯出 Excel 檔案的功能，要用到 FileResult 下載檔案

    //TODO: ? 如果所有的 table 都加上這個功能 , 那 relaction 是否也要同步調整 , read repository 要如何做
    //TODO: ? 刪除復原 @@
    //TODO: ? Master Detail Relaction 限制
    //TODO: ? commind 鎖定在 Repository
    //注意事項
    //請在你的 GitHub 建立一個獨立專案，並將本次作業上傳到 GitHub，並提交 GitHub 專案網址回來。教學影片: https://youtu.be/Vp6sjldOQUk
    //請到 FB 社團回報作業
    //第一周作業回報(請上傳作業到 GitHub 並回報連結)
    //做不出來沒關係，請在回報進度時寫上你哪幾個功能無法完成，或實作時發生的疑問！

    public class HomeController : Controller
    {
        //TODO:實作表單驗證機制 (FormsAuthentication) 
        //* 要在「客戶資料」表格加上【帳號】、【密碼】欄位
        //* 密碼欄位須加密或做雜湊處裡(Hash) (SHA256)
        //* 要有登入、登出功能
        //* 參考文章: http://blog.miniasp.com/post/2008/02/20/Explain-Forms-Authentication-in-ASPNET-20.aspx
        //* 客戶登入後只有一個【修改客戶資料】功能，但只能修改【密碼、電話、傳真、地址、Email】等欄位，其他欄位不能被修改或更新。

        I客戶資料Repository _客戶資料Repository;

        public HomeController()
        {
            _客戶資料Repository = RepositoryHelper.Get客戶資料Repository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                客戶資料 tmp = _客戶資料Repository.Where(a => a.帳號.Equals(客戶資料.帳號) && a.密碼.Equals(客戶資料.密碼)).FirstOrDefault();
                if (null != tmp)
                {
                    tmp.密碼 = "";

                    String userData = new JavaScriptSerializer().Serialize(tmp);
                    Boolean IsPersistent = true;
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, tmp.帳號, DateTime.Now, DateTime.Now.AddHours(1), IsPersistent, userData, FormsAuthentication.FormsCookiePath);
                    var encryptTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                    cookie.HttpOnly = true;
                    this.Response.AppendCookie(cookie);

                    return RedirectToAction("Index", "客戶明細", null);
                }
                else
                {
                    ModelState.AddModelError("", "帳密錯誤");
                }
            }

            return View(客戶資料);
        }
    }
}