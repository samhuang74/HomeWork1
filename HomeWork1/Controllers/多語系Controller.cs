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
            //設定使用語系
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            return View();
        }
    }
}