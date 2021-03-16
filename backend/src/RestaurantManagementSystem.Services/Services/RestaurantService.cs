using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using RestaurantManagementSystem.Services.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Services
{
    /// <summary>
    /// Restaurant Service
    /// </summary>
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantService"/> class
        /// </summary>
        /// <param name="restaurantRepository">Restaurant Repository</param>
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        /// <summary>
        /// Get the restaurant
        /// </summary>
        /// <param name="id">ID of the restaurant</param>
        /// <returns>A <see cref="Task"/> of type <see cref="Restaurant"/></returns>
        public async Task<Restaurant> GetById(string id)
        {
            var find = await _restaurantRepository.FindAsync(id);
            return find;
        }

        /// <summary>
        /// Gets all the restaurants
        /// </summary>
        /// <returns>A <see cref="Task"/> of Lists of type <see cref="Restaurant"/></returns>
        public async Task<List<Restaurant>> GetAll()
        {
            var find = await _restaurantRepository.AllAsync();
            return find;
        }
    }
}
