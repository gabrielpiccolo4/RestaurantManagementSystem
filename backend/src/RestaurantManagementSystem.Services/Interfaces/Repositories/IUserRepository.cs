using RestaurantManagementSystem.Services.Entities;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Interfaces.Repositories
{
    /// <summary>
    /// Interface for the User Repository
    /// </summary>
    public interface IUserRepository : IAsyncRepository<User>
    {
        /// <summary>
        /// Find the User
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>A <see cref="Task"/> of type <see cref="User"/></returns>
        Task<User> FindAsync(string username, string password);
    }
}
