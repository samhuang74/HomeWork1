using HomeWork1.Models;
using HomeWork1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork1.Controllers
{
    public class 客戶明細Controller : Controller
    {
        Iv_客戶明細Service _客戶明細Service;

        //IRepository<客戶明細> _客戶明細Repository;
        //private CustomerEntities db = new CustomerEntities();

        public 客戶明細Controller(Iv_客戶明細Service 客戶明細Service)
        {
            this._客戶明細Service = 客戶明細Service;
        }

        // GET: 客戶明細
        public ActionResult Index()
        {
            return View(_客戶明細Service.Reads());
        }
    }
}
