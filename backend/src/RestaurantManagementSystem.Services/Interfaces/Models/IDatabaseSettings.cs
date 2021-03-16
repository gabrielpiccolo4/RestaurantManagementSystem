namespace RestaurantManagementSystem.Services.Interfaces.Models
{
    /// <summary>
    /// Interface for the Database Settings
    /// </summary>
    public interface IDatabaseSettings
    {
        /// <summary>
        /// Name of the cluster
        /// </summary>
        string ClusterName { get; set; }

        /// <summary>
        /// Name of the database
        /// </summary>
        string DatabaseName { get; set; }

        /// <summary>
        /// Username of the cluster
        /// </summary>
        string Login { get; set; }

        /// <summary>
        /// Password of the cluster
        /// </summary>
        string Password { get; set; }
    }
}