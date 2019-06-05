using HomeWork1.Exceptions;
using HomeWork1.Models;
using HomeWork1.Services;
using HomeWork1.Utils;
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

    public class HomeController : Controller
    {
        I客戶資料Service _客戶資料Service;

        public HomeController()
        { }

        public HomeController(I客戶資料Service 客戶資料Service)
        {
            _客戶資料Service = 客戶資料Service;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HandleError(View = "NormalError", ExceptionType = typeof(Exception))]
        [HandleError(View = "CustomerError", ExceptionType = typeof(CustomerException))]
        public ActionResult ExceptionController(String id)
        {
            if ("Customer".Equals(id))
            {
                throw new CustomerException("錯誤訊息測試");
            }
            else
            {
                throw new Exception("錯誤訊息測試");
            }

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String 帳號, String 密碼)
        {
            if (!String.IsNullOrEmpty(帳號) && !String.IsNullOrEmpty(密碼))
            {
                密碼 = CryptographyUtils.SHA256Cryp(密碼);
                客戶資料 tmp = _客戶資料Service.Reads().Where(a => a.帳號.Equals(帳號) && a.密碼.Equals(密碼)).FirstOrDefault();
                if (null != tmp)
                {
                    tmp.密碼 = "";

                    String userData = "";//new JavaScriptSerializer().Serialize(tmp);
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

            ViewBag.帳號 = 帳號;

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}