using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;


namespace AdminKiosco.Web
{
    public static class RouteConfig
    {
        private static MetaModel s_defaultModel = new MetaModel();
        public static MetaModel DefaultModel
        {
            get
            {
                return s_defaultModel;
            }
        }

        public static IEnumerable<MetaTable> PublicTables { get; set;}
        public static string HiddenTables { get; set; } 
    
        public static void RegisterRoutes(RouteCollection routes)
        {
            //                    IMPORTANT: DATA MODEL REGISTRATION 
            // Uncomment this line to register an ADO.NET Entity Framework model for ASP.NET Dynamic Data.
            // Set ScaffoldAllTables = true only if you are sure that you want all tables in the
            // data model to support a scaffold (i.e. templates) view. To control scaffolding for
            // individual tables, create a partial class for the table and apply the
            // [ScaffoldTable(true)] attribute to the partial class.
            // Note: Make sure that you change "YourDataContextType" to the name of the data context
            // class in your application.
            // See http://go.microsoft.com/fwlink/?LinkId=257395 for more information on how to register Entity Data Model with Dynamic Data            
            DefaultModel.RegisterContext(() =>
            {
                return ((IObjectContextAdapter)new AdminKiosco.Entities.PaperEntities()).ObjectContext;
            }, new ContextConfiguration() { ScaffoldAllTables = true });

            // The following registration should be used if YourDataContextType does not derive from DbContext
            // DefaultModel.RegisterContext(typeof(YourDataContextType), new ContextConfiguration() { ScaffoldAllTables = false });

            // The following statement supports separate-page mode, where the List, Detail, Insert, and 
            // Update tasks are performed by using separate pages. To enable this mode, uncomment the following 
            // route definition, and comment out the route definitions in the combined-page mode section that follows.
            routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
            {
                Constraints = new RouteValueDictionary(new { action = "List|Details|Edit|Insert" }),
                Model = DefaultModel
            });

            HiddenTables = ConfigurationManager.AppSettings["hiddenTables"];
            


            // The following statements support combined-page mode, where the List, Detail, Insert, and
            // Update tasks are performed by using the same page. To enable this mode, uncomment the
            // following routes and comment out the route definition in the separate-page mode section above.
            routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
                Action = PageAction.List,
                ViewName = "ListDetails",
                Model = DefaultModel
            });

            //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
            //    Action = PageAction.Details,
            //    ViewName = "ListDetails",
            //    Model = DefaultModel
            //});

        }

        public static IEnumerable<MetaTable> VisibleTables
        {
            get
            {
                if (!string.IsNullOrEmpty(RouteConfig.HiddenTables))
                {
                    return from v in DefaultModel.VisibleTables
                           where !RouteConfig.HiddenTables.Contains(v.Name.ToString())
                           select v;
                }
                else
                {
                    return new List<MetaTable>();
                }
            }
        }
    }
}
