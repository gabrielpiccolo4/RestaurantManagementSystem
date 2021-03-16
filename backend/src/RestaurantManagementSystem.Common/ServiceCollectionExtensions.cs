using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace RestaurantManagementSystem.Common
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterImplementationsOfServiceType(this IServiceCollection services, Assembly assembly, Type type)
        {
            var implementationsType = assembly.GetTypes().Where(x => !x.IsInterface && x.GetInterface(type.Name) != null);
            foreach (var implementationType in implementationsType)
            {
                var servicesType = implementationType.GetInterfaces().Where(r => !r.Name.Contains(type.Name));
                foreach (var serviceType in servicesType)
                    services.AddSingleton(serviceType, implementationType);
            }
        }
    }
}
