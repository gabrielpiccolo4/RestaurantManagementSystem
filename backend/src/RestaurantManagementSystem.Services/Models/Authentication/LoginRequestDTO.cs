using System.ComponentModel.DataAnnotations;

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
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
