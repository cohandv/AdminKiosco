using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using AdminKiosco.HTML5;
using AdminKiosco.Web;

namespace AdminKiosco.Web
{
    public class Global : HttpApplication
    {
  

        //void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    if (Request.AppRelativeCurrentExecutionFilePath == "~/")
        //        HttpContext.Current.RewritePath("~/default.aspx");
        //}
        void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Get the exception object.
            Exception exc = Server.GetLastError();

            if (exc != null)
            {
                // Handle HTTP errors
                if (exc.GetType() == typeof(HttpException))
                {
                    // The Complete Error Handling Example generates
                    // some errors using URLs with "NoCatch" in them;
                    // ignore these here to simulate what would happen
                    // if a global.asax handler were not implemented.
                    if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                        return;
                }

            }

            // Clear the error from the server
            Server.ClearError();

        }
    }
}
