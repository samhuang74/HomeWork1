using HomeWork1.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }

        private static void SetDbHTTPContext()
        {
            HttpContext.Current.Items[Repositories.FieldKey.DB_CONTEXT_KEY] = new CustomerEntities();
        }
    }
}
