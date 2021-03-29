namespace RestaurantManagementSystem.Application.Models.Authentication
{
    /// <summary>
    /// Sign up request DTO
    /// </summary>
    public class SignUpRequestDTO
    {
        /// <summary>
        /// Full name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

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
