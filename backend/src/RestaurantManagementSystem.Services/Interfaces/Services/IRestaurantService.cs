using RestaurantManagementSystem.Services.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Interfaces.Services
{
    /// <summary>
    /// Interface for the Restaurant Service
    /// </summary>
    public interface IRestaurantService : IService
    {
        /// <summary>
        /// Find the restaurant by id
        /// </summary>
        /// <param name="id">ID of the restaurant</param>
        /// <returns>A <see cref="Task"/> of type <see cref="Restaurant"/></returns>
        Task<Restaurant> GetById(string id);

        /// <summary>
        /// Find all restaurants
        /// </summary>
        /// <returns>A <see cref="Task"/> of Lists of type <see cref="Restaurant"/></returns>
        Task<List<Restaurant>> GetAll();
    }
}
