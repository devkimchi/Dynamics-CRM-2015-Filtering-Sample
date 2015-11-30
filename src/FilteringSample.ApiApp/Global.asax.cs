using System.Web.Http;

using FilteringSample.ApiApp;

namespace DevKimchi.FilteringSample.ApiApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
