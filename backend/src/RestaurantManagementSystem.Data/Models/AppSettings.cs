using RestaurantManagementSystem.Services.Interfaces.Models;

namespace RestaurantManagementSystem.Infrastructure.Models
{
    public class AppSettings : IAppSettings
    {
        public const string SectionName = "App";

        public string JwtSecret { get; set; }

        public string AesKey { get; set; }
    }
}
