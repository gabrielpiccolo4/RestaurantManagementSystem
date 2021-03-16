using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagementSystem.Infrastructure.Data;
using RestaurantManagementSystem.Infrastructure.Models;
using RestaurantManagementSystem.Services.Interfaces.Data;
using RestaurantManagementSystem.Services.Interfaces.Models;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using System.Reflection;

namespace RestaurantManagementSystem.Common
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = new DatabaseSettings();
            configuration.GetSection(DatabaseSettings.SectionName).Bind(databaseSettings);

            var appSettings = new AppSettings();
            configuration.GetSection(AppSettings.SectionName).Bind(appSettings);

            services.AddSingleton<IDatabaseSettings>(databaseSettings);
            services.AddSingleton<IAppSettings>(appSettings);
            services.AddSingleton<IMongoContext, MongoContext>();

            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterImplementationsOfServiceType(assembly, typeof(IAsyncRepository<>));
        }
    }
}
