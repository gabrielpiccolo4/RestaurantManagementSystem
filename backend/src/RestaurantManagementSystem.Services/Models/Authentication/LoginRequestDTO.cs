namespace RestaurantManagementSystem.Application.Models.Authentication
{
    /// <summary>
    /// Login request DTO
    /// </summary>
    public class LoginRequestDTO
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
