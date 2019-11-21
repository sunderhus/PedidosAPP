using AppDePedidos.Data.Services;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AppDePedidos.BL
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
            containerBuilder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            containerBuilder.RegisterType<SqlRestauranteDados>()
                            .As<IRestaurante>()
                            .InstancePerHttpRequest();
            containerBuilder.RegisterType<AppDePedidosDbContext>().InstancePerHttpRequest();

            var container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}