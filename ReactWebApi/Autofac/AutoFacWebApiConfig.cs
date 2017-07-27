using Autofac;
using Autofac.Integration.WebApi;
using ReactWebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ReactWebApi.Autofac
{
    public static class AutoFacWebApiConfig
    {
        public static void InitialiseAutofac()
        {
            InitialiseAutofacServices();
        }

        private static void InitialiseAutofacServices()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<MyTestProvider>()
                .AsSelf()
                .InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}