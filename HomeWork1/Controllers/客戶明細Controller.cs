using HomeWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork1.Controllers
{
    public class 客戶明細Controller : Controller
    {
        private CustomerEntities db = new CustomerEntities();

        // GET: 客戶明細
        public ActionResult Index()
        {
            return View(db.客戶明細.ToList());
        }        
    }
}
