using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace HomeWork1.Filters
{
    public class ActionDebug2Console : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("End : " + DateTime.Now.ToLongTimeString());
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("Start : " + DateTime.Now.ToLongTimeString());
        }
    }
}