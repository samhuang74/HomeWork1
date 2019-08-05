using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace HomeWork1.Filters
{

    /// <summary>
    /// Exception Filter and write to NLog
    /// </summary>
    public class LogErrorsAttribute : FilterAttribute, IExceptionFilter
    {
        #region IExceptionFilter Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            if (filterContext != null && filterContext.Exception != null)
            {
                WriteLog(filterContext);
                //為了保留 錯誤訊息 設定的一致性 所以還是透過 web.config 的設定為主 , 不希望在程式中寫死 , 如果之後有需要可以參考下面的擴充

                //Exception exception = filterContext.Exception;
                //if (filterContext.ExceptionHandled == true)
                //{
                //    return;
                //}
                //HttpException httpException = new HttpException(null, exception);
                ////filterContext.Exception.Message可获取错误信息

                ///*
                // * 1、根据对应的HTTP错误码跳转到错误页面
                // * 2、先对Action方法里引发的HTTP 404/400错误进行捕捉和处理
                // * 3、其他错误默认为HTTP 500服务器错误
                // */
                //if (httpException != null && (httpException.GetHttpCode() == 400 || httpException.GetHttpCode() == 404))
                //{
                //    filterContext.HttpContext.Response.StatusCode = 404;
                //    filterContext.HttpContext.Response.WriteFile("~/HttpError/404.html");
                //}
                //else
                //{
                //    filterContext.HttpContext.Response.StatusCode = 500;
                //    filterContext.HttpContext.Response.WriteFile("~/HttpError/500.html");
                //}

                ///*---------------------------------------------------------
                // * 这里可进行相关自定义业务处理，比如日志记录等
                // ---------------------------------------------------------*/
                //WriteLog(filterContext);

                ////设置异常已经处理,否则会被其他异常过滤器覆盖
                //filterContext.ExceptionHandled = true;

                ////在派生类中重写时，获取或设置一个值，该值指定是否禁用IIS自定义错误。
                //filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

                //20190429 redirect error page 
                //filterContext.Result = new ViewResult()
                //{
                //    ViewName = "Error"
                //};                
                //filterContext.ExceptionHandled = true;

                //20190530 Log 之後 redirect to error page
                //String controllerName = "Error";
                //String actionName = "";
                //String viewName = "";
                //var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                //var result = new ViewResult
                //{
                //    ViewName = viewName,
                //    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                //    TempData = filterContext.Controller.TempData
                //};

                //filterContext.Result = result;
                //filterContext.ExceptionHandled = true;
                //filterContext.HttpContext.Response.Clear();
                //filterContext.HttpContext.Response.StatusCode = 500;
                //filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

                //var version = Assembly.GetExecutingAssembly().GetName().Version;
                //filterContext.Controller.ViewData["Version"] = version.ToString();
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        private void WriteLog(ExceptionContext filterContext)
        {
            if (null != filterContext)
            {
                //之後如果有需要可以針對丟出來的錯誤訊息做處理
                Exception exception = filterContext.Exception;

                // 訊息管理器
                Logger logger = LogManager.GetCurrentClassLogger();

                string userName = "no login ";
                if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    userName = filterContext.HttpContext.User.Identity.Name;
                }

                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                string message = string.Format("{0} exec {1}Controller.{2} exception", userName, controller, action);

                logger.Error(filterContext.Exception, message);
            }
        }
    }

    /// <summary>
    /// Controller 攔截器擴增屬性
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    sealed class InterceptorOfControllerAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 執行 Action 觸發事件
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 訊息管理器
            Logger logger = LogManager.GetCurrentClassLogger();

            string userName = "no login ";
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                userName = filterContext.HttpContext.User.Identity.Name;
            }

            // 參數資訊
            string parametersInfo = JsonConvert.SerializeObject(filterContext.ActionParameters, new JsonSerializerSettings()
            {
                ContractResolver = new ReadablePropertiesOnlyResolver()
            });

            // 運行中的 Controller & Action 資訊
            string controllerName = filterContext.Controller.GetType().Name;
            string actionName = filterContext.ActionDescriptor.ActionName;

            // 訊息內容
            string message = string.Format(
                "{0} execute {1}.{2}() => {3}",
                userName,
                controllerName,
                actionName,
                string.IsNullOrEmpty(parametersInfo) ? "(void)" : parametersInfo
            );

            // 寫入訊息
            logger.Info(message);
        }
    }

    /// <summary>
    /// JsonSerializer 讀取屬性的解析器設定
    /// </summary>
    class ReadablePropertiesOnlyResolver : DefaultContractResolver
    {
        /// <summary>
        /// 建立可呈現（解析）的屬性
        /// </summary>
        /// <returns>呈現的屬性</returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (typeof(Stream).IsAssignableFrom(property.PropertyType))
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}