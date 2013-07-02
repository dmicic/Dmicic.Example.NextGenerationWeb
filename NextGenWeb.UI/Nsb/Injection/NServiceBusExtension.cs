using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NextGenWeb.UI.Nsb.Injection
{
    public static class NServiceBusExtension
    {
        public static Configure ForMvc(this Configure configure)
        {
            configure.Configurer.RegisterSingleton(typeof(IControllerActivator),
                new NServiceBusControllerActivator());

            var controllers = Configure.TypesToScan
                .Where(t => typeof(IController).IsAssignableFrom(t));

            foreach (Type type in controllers)
                configure.Configurer.ConfigureComponent(type, DependencyLifecycle.InstancePerCall);

            DependencyResolver.SetResolver(new NServiceBusDependencyResolverAdapter(configure.Builder));

            return configure;
        }
    }
}