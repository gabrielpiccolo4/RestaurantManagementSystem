namespace RestaurantManagementSystem.Application.Models.Authentication
{
    /// <summary>
    /// Login request DTO
    /// </summary>
    public class LoginRequestDTO
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
