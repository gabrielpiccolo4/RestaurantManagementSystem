using RestaurantManagementSystem.Application.Models.Authentication;
using RestaurantManagementSystem.Services.Entities;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Interfaces.Services.Authentication
{
    /// <summary>
    /// Interface for the Sign Up Service
    /// </summary>
    public interface ISignUpService : IService
    {
        /// <summary>
        /// Creates an account for the user
        /// </summary>
        /// <param name="user">An instance of <see cref="User"/></param>
        /// <returns>An instance of <see cref="User"/></returns>
        Task<User> SignUp(User user);
    }
}
