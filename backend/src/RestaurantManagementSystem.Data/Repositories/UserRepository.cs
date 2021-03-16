using RestaurantManagementSystem.Common.Enums;
using RestaurantManagementSystem.Infrastructure.Data;
using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Data;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Repositories
{
    /// <summary>
    /// User Repository
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="context">Instance of <see cref="MongoContext"/></param>
        public UserRepository(IMongoContext context) : base(context)
        {
        }

        /// <summary>
        /// Find the user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Passowrd</param>
        /// <returns>A <see cref="Task"/> of type <see cref="User"/></returns>
        public async Task<User> FindAsync(string username, string password)
        {
            return new User()
            {
                Username = "Piccolo",
                Name = "Gabriel",
                Email = "dsads@dassa.com",
                Roles = new List<Roles>() { Roles.User }
            };
        }
    }
}
