using System.Web.Http;
using ViBANManager.API.App_Start;

namespace ViBANManager.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Register Service
            IocConfig.RegisterServices(); 
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
