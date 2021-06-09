using Ino_InvisionCore.Presentacion.Exceptions;
using Ino_InvisionCore.Presentacion.Models;
using Ino_InvisionCore.Presentacion.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ino_InvisionCore.Presentacion.Filters
{
    public class ActionWorkFilter : ActionFilterAttribute
    {
        const string K_TimeObserver = "__private_timeObserver__";
        const string K_LogContext = "__private_logContext__";
        const string K_ContextId = "ContextID";

        public Type SerializeSettings = null;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            TimeObserver timeObserver = new TimeObserver("").Start();
            filterContext.HttpContext.Items[K_TimeObserver] = timeObserver;

            IDictionary<string, object> paramsMap = filterContext.ActionArguments;

            var prams = GetParamsJson(paramsMap);

            object logContext = BuildLogContextInfo(paramsMap);
            if (logContext != null)
            {
                IDisposable logContextDisposable = LogContext.PushProperty(K_ContextId, logContext);
                filterContext.HttpContext.Items[K_LogContext] = logContextDisposable;
            }
            LogInfo("ACTION_START", filterContext.RouteData, "params=" + prams);
        }

        private string GetParamsJson(IDictionary<string, object> paramsMap)
        {
            string prams;
            if (SerializeSettings == null)
            {
                prams = ObjectDumper.DumpJson(paramsMap.Values);
            }
            else
            {
                var instanceObj = Activator.CreateInstance(SerializeSettings);
                var instance = (DefaultContractResolver)instanceObj;

                if (instance != null)
                {
                    var settings = new JsonSerializerSettings
                    {
                        ContractResolver = instance
                    };
                    prams = ObjectDumper.DumpJson(paramsMap.Values, settings: settings);
                }
                else
                {
                    prams = ObjectDumper.DumpJson(paramsMap.Values);
                }
            }
            return prams;
        }

        private static object BuildLogContextInfo(IDictionary<string, object> paramsMap)
        {
            if (paramsMap.Count != 1)
                return null;

            object paramVal = paramsMap.Values.First();
            object logContext = null;

            if ((paramVal as ActionWorkFilterLogContext) != null)
            {
                logContext = ((ActionWorkFilterLogContext)paramVal).GetLogContext();
            }
            else
            {
                logContext = paramVal;
            }
            return logContext;
        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            TimeObserver timeObserver = (TimeObserver)filterContext.HttpContext.Items[K_TimeObserver];
            string errorCode = null;
            if (filterContext.Exception != null)
            {
                bool logYaImpreso = BusinessException.LogPrinted(filterContext.Exception);
                if (!logYaImpreso)
                    Log.Error("OnActionExecuted Exception {@Exception}", filterContext.Exception);
                errorCode = "GG001";
                BusinessException ex = filterContext.Exception as BusinessException;
                if (ex != null)
                    errorCode = ex.ErrorCode;
                StatusResponse statusResponse = new StatusResponse(errorCode, filterContext.Exception.Message);
                filterContext.Result = new ObjectResult(statusResponse);
            }

            var httstatuscode = filterContext.HttpContext.Response.StatusCode;
            object filterContextResult = filterContext.Result;
            //if ((filterContextResult as OkObjectResult) != null)
            //    filterContextResult = ((OkObjectResult) filterContextResult).Value;
            // todo: No siempre el contenido va a poder serializado en json (Controlar FileResult)
            //string jsonStr = filterContextResult.ToJson();
            var rslt = "code=" + httstatuscode + ",response=" + filterContextResult;
            LogInfo("ACTION_END ", filterContext.RouteData, rslt, filterContext.Exception, timeObserver, errorCode);
            if (filterContext.HttpContext.Items.ContainsKey(K_LogContext))
            {
                IDisposable logContextDisposable = (IDisposable)filterContext.HttpContext.Items[K_LogContext];
                logContextDisposable.Dispose();
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //LogInfo("OnResultExecuting", filterContext.RouteData, "");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //LogInfo("OnResultExecuted", filterContext.RouteData, "");
        }

        private void LogInfo(string methodName, RouteData routeData, string obs, Exception exception = null, TimeObserver timeObserver = null, string errorCode = null)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            string elapsed = timeObserver != null ? (string)timeObserver.CalcElapsedStr() : "";
            string errorInfo = "";
            if (exception != null)
            {
                var isLogPrinted = BusinessException.LogPrinted(exception);
                errorInfo = isLogPrinted ? exception.Message : exception.ToString();
            }
            if (errorCode == null) errorCode = "";
            var message = string.Format("***{0} {1}.{2}({3}) {4} {5} {6}", methodName, controllerName, actionName, obs, errorCode, elapsed, errorInfo);
            Debug.WriteLine("==================================================================");
            Debug.WriteLine("");
            Debug.WriteLine(message, "Se esta ejecutando el metodo ");
            Debug.WriteLine("");
            Debug.WriteLine("==================================================================");
            Log.Information(message);
            //if (exception!=null)
            //    Log.Information(exception, "");
        }
    }
}
