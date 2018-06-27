using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Dashboard_Bajas_Carrier
{
    public class Global : HttpApplication
    {
        public static string user { set; get; } 
        public static int logueado { set; get; }     
        public static int carrier { set; get; }
        public static int privilegio { set; get; }
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}