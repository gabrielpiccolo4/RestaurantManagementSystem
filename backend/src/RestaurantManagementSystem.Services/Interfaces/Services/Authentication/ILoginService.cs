using RestaurantManagementSystem.Application.Models.Authentication;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Interfaces.Services.Authentication
{
    /// <summary>
    /// Interface for the Login Service
    /// </summary>
    public interface ILoginService : IService
    {
        /// <summary>
        /// Login for the user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Passowrd</param>
        /// <returns>An instance of <see cref="LoginResponseDTO"/></returns>
        Task<LoginResponseDTO> Login(string username, string password);
    }
}
