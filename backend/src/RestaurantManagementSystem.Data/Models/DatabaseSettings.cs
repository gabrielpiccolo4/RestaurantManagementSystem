using RestaurantManagementSystem.Services.Interfaces.Models;

namespace RestaurantManagementSystem.Infrastructure.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public const string SectionName = "Database";

        public string ClusterName { get; set; }
        public string DatabaseName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
