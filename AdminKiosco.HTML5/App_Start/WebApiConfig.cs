using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Builder;
using Microsoft.OData.Edm;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.Http;
using AdminKiosco.HTML5.Model;

namespace AdminKiosco.HTML5
{
    public static class WebApiConfig
    {
        public static IEdmModel GetModel()
        {
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Feriado>("Feriados");


            return modelBuilder.GetEdmModel();
        }

        public static void Register(HttpConfiguration config)
        {
            GlobalConfiguration.Configuration.MapODataServiceRoute(routeName: "OData", routePrefix: "api", model: GetModel());
            GlobalConfiguration.Configuration.EnsureInitialized();
            return;
        }
    }
}