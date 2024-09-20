using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OkuTara_Deneme_2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();

            Response.Clear();

            HttpException httpException = new HttpException(exception.Message, exception);

            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;
                    case 500:
                        action = "InternalServer";
                        break;
                    case 401:
                        action = "Unauthorized";
                        break;
                    default:
                        action = "Unknown"; // Diğer hatalar için farklı bir sayfa kullanabilirsin
                        break;
                }

                Server.ClearError();

                Response.Redirect($"/Error/{action}");
            }
        }
    }
}
