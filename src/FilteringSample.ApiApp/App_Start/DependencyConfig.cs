using System.Reflection;

using Autofac;
using Autofac.Integration.WebApi;

using DevKimchi.Crm.Proxies;

using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;

namespace DevKimchi.FilteringSample.ApiApp
{
    /// <summary>
    /// This represents the configuration entity for dependency injection.
    /// </summary>
    public static class DependencyConfig
    {
        /// <summary>
        /// Configures <see cref="Autofac" /> dependency injection.
        /// </summary>
        /// <returns>Returns <see cref="IContainer" /> instance.</returns>
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            RegisterCrmProxies(builder);
            RegisterControllers(builder);

            var container = builder.Build();
            return container;
        }

        private static void RegisterCrmProxies(ContainerBuilder builder)
        {
            builder.Register(c => new CrmConnection("OrganisationServiceContext")).PropertiesAutowired().InstancePerLifetimeScope();
            builder.Register(c => new OrganizationService(c.Resolve<CrmConnection>())).As<IOrganizationService>().PropertiesAutowired().InstancePerLifetimeScope();
            builder.Register(c => new OrganisationServiceContext(c.Resolve<IOrganizationService>())).As<IOrganisationServiceContext>().PropertiesAutowired().InstancePerLifetimeScope();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired().InstancePerLifetimeScope();
        }
    }
}