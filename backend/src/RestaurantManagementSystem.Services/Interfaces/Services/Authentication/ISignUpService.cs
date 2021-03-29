using RestaurantManagementSystem.Application.Models.Authentication;
using RestaurantManagementSystem.Services.Entities;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Interfaces.Services.Authentication
{
    /// <summary>
    /// Interface for the Sign up Service
    /// </summary>
    public interface ISignUpService : IService
    {
        /// <summary>
        /// Sign up for the user
        /// </summary>
        /// <param name="user">An instance of <see cref="User"/></param>
        /// <returns>An instance of <see cref="User"/></returns>
        Task<User> Signup(User user);
    }
}
