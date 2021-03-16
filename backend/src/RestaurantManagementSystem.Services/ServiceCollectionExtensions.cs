using Microsoft.Extensions.DependencyInjection;
using RestaurantManagementSystem.Common;
using RestaurantManagementSystem.Services.Interfaces.Services;
using System.Reflection;

namespace RestaurantManagementSystem.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.RegisterImplementationsOfServiceType(assembly, typeof(IService));
        }
    }
}
