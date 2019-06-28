﻿using HomeWork1.Models;
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
            SetDbHTTPContext();

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
            CultureInfo ci = null;
            try
            {
                //有request 才要切換 
                String lan = Request.Cookies["ntustLan"].Value;
                if (!String.IsNullOrEmpty(lan))
                {

                }

                //取得用戶端語言喜好設定(已排序的字串陣列)
                var userLanguages = Request.UserLanguages;

                if (userLanguages.Length > 0)
                {
                    try
                    {
                        ci = new CultureInfo(userLanguages[0]);
                    }
                    catch (CultureNotFoundException)
                    {
                        ci = CultureInfo.InvariantCulture;
                    }
                }
                else
                {
                    ci = CultureInfo.InvariantCulture;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            }
        }
    }

}
