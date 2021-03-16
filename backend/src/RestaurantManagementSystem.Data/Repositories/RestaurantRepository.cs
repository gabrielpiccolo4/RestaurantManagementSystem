using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Data;
using RestaurantManagementSystem.Services.Interfaces.Repositories;

namespace RestaurantManagementSystem.Infrastructure.Repositories
{
    /// <summary>
    /// Restaurant Repository
    /// </summary>
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantRepository"/> class
        /// </summary>
        /// <param name="context">MongoContext</param>
        public RestaurantRepository(IMongoContext context) : base(context)
        {
        }
    }
}
