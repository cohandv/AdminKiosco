using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Builder;
using Microsoft.OData.Edm;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;

namespace AdminKiosco.HTML5
{
    public class WebApiConfig
    {
        public static IEdmModel GetModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<AdminKiosco.Entities.aspnet_Roles>("aspnet_Roles");
            builder.EntitySet<AdminKiosco.Entities.aspnet_Users>("aspnet_Users");
            builder.EntitySet<AdminKiosco.Entities.KioscoUsuario>("KioscoUsuario");
            builder.EntitySet<AdminKiosco.Entities.Kiosco>("Kiosco");

            return builder.GetEdmModel();
        }

        public static void Register()
        {
            ODataRoute route = config.Routes.MapODataServiceRoute("odata", "odata", GetModel());
            route.MapODataRouteAttributes(config);
        }
    }
}