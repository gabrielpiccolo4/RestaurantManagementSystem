using RestaurantManagementSystem.Services.Entities;

namespace RestaurantManagementSystem.Services.Interfaces.Services.Authentication
{
    /// <summary>
    /// Interface for the Token Service
    /// </summary>
    public interface ITokenService : IService
    {
        /// <summary>
        /// Generates the token based on the user
        /// </summary>
        /// <param name="user">Instance of <see cref="User"/></param>
        /// <returns>Token</returns>
        string GenerateToken(User user);
    }
}
