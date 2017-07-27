using ReactWebApi.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ReactWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoFacWebApiConfig.InitialiseAutofac();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
        }
    }
}
