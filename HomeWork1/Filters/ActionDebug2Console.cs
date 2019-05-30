using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HomeWork1.Filters
{
    public class ActionDebug2Console : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {            
            
            System.Console.WriteLine("[" + Thread.CurrentThread.Name + "] Start : " + DateTime.Now.ToLongTimeString());
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            System.Console.WriteLine("[" + Thread.CurrentThread.Name + "] End : " + DateTime.Now.ToLongTimeString());
        }
    }
}