using HomeWork1.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HomeWork1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //repository
            UnityConfig.RegisterComponents();
        }

        protected void Application_BeginRequest()
        {
            //設定DB Connection
            SetDbHTTPContext();

            //設定語系
            SetLanguage(Request);
        }

        private static void SetDbHTTPContext()
        {
            DbContext dbContext = new CustomerEntities();
            //dbContext.Database.Log = (sql) =>
            //{                
            //    System.IO.File.AppendText(HostingEnvironment.MapPath(@"~\App_Data\logs.txt"));
            //};
            HttpContext.Current.Items[Repositories.FieldKey.DB_CONTEXT_KEY] = dbContext;
        }

        private static void SetLanguage(HttpRequest Request)
        {
            try
            {
                String lan = null;

                if (!String.IsNullOrEmpty(Request.QueryString["ntustLan"]))
                {
                    var cookie = Request.Cookies["ntustLan"] ?? new HttpCookie("ntustLan");
                    cookie.HttpOnly = true;
                    cookie.Value = Request.QueryString["ntustLan"];
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    lan = Request.QueryString["ntustLan"];
                }
                else if (null != Request.Cookies["ntustLan"])
                {
                    lan = Request.Cookies["ntustLan"].Value;

                    //取得用戶端語言喜好設定(已排序的字串陣列)
                    //var userLanguages = Request.UserLanguages;
                    //if (userLanguages.Length > 0)
                    //{
                    //    try
                    //    {
                    //        ci = new CultureInfo(userLanguages[0]);
                    //    }
                    //    catch (CultureNotFoundException)
                    //    {
                    //        ci = CultureInfo.InvariantCulture;
                    //    }
                    //}
                    //else
                    //{
                    //    ci = CultureInfo.InvariantCulture;
                    //}
                }
                else if (null == Request.Cookies["ntustLan"])
                {
                    String defaultLan = "zh-TW";
                    var cookie = Request.Cookies["ntustLan"] ?? new HttpCookie("ntustLan");
                    cookie.HttpOnly = true;
                    cookie.Value = defaultLan;
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    lan = defaultLan;
                }

                if (!String.IsNullOrEmpty(lan))
                {
                    CultureInfo ci = new CultureInfo(lan);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                    System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                }
            }
            catch (Exception)
            { }
        }
    }

}
