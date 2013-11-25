using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using AdminKiosco.Web;

namespace AdminKiosco.Web
{
    public class Global : HttpApplication
    {
  

        private static void RegisterScripts()
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-1.8.2.min.js",
                DebugPath = "~/Scripts/jquery-1.8.2.js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });
        }

        //void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    if (Request.AppRelativeCurrentExecutionFilePath == "~/")
        //        HttpContext.Current.RewritePath("~/default.aspx");
        //}
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterScripts();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

            // Get the exception object.
            Exception exc = Server.GetLastError();

            // Handle HTTP errors
            if (exc.GetType() == typeof(HttpException))
            {
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                Server.Transfer("~/Error.aspx");
            }

            // Log the exception and notify system operators
            //TODO IMPLEMENT SECURITY IN DATABASE!
            EventLog.WriteEntry("Application", exc.Message + System.Environment.NewLine + exc.StackTrace);

            // Clear the error from the server
            Server.ClearError();

            Server.Transfer("~/Error.aspx");
        }
    }
}
