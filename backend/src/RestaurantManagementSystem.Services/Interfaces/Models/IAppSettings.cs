namespace RestaurantManagementSystem.Services.Interfaces.Models
{
    /// <summary>
    /// Interface for the App Settings
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// JSON Web Token Secret
        /// </summary>
        public string JwtSecret { get; set; }

        /// <summary>
        /// AES Cryptography Key
        /// </summary>
        public string AesKey { get; set; }
    }
}
