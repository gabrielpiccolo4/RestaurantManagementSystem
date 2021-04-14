using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Name { get; set; }

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
        [MinLength(6, ErrorMessage = "Password must be 6 characters or more.")]
        public string Password { get; set; }
    }
}
