using RestaurantManagementSystem.Services.Entities;

namespace RestaurantManagementSystem.Application.Models.Authentication
{
    /// <summary>
    /// Login response DTO
    /// </summary>
    public class LoginResponseDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResponseDTO"/> class
        /// </summary>
        /// <param name="token">Token to use as authentication</param>
        /// <param name="user"></param>
        public LoginResponseDTO(string token, User user)
        {
            Token = token;
            User = user;
        }

        /// <summary>
        /// Token generated
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// User logged in
        /// </summary>
        public User User { get; set; }
    }
}
