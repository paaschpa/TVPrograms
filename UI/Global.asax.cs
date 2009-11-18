using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TVPrograms.UI.Models.Forms;

namespace TVPrograms.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            routes.Add(new Route
            ("Network/ListData/{id}", new MvcRouteHandler())
                {
                    Defaults = new RouteValueDictionary( 
		            new {controller = "Network", action = "ListData", id=""}
                    ),
                }
            );

        }


        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            AutoMapperConfiguration.Configure();
            BootStrapper.ConfigureStructureMap();
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
        }
    }
}