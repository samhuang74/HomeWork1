using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HomeWork1.Controllers
{
    public class 多語系Controller : Controller
    {
        // GET: 多語系
        public ActionResult Index(String lang = "")
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public ActionResult SetCulture(String ntustLan = "")
        {
            if (!String.IsNullOrEmpty(ntustLan))
            {
                var cookie = Request.Cookies["ntustLan"] ?? new HttpCookie("ntustLan");
                cookie.HttpOnly = true;
                cookie.Value = Server.UrlEncode(ntustLan);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Index");
        }
    }
}