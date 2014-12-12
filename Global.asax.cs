using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using BarApplication;
using BarDataAccessLayer;

namespace BarApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            // Code that runs on application end

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        //public void Session_OnEnd()
        //{
        //    var stolUProcesuNarudzbe = new StolDb();
        //    stolUProcesuNarudzbe.StolSlobodanZauzet(0, (int)Session["StolSlobodanZauzet"]);
        //}
    }
}
