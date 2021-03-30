using RestaurantManagementSystem.Infrastructure.Data;
using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Data;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using RestaurantManagementSystem.Common.Helpers;
using RestaurantManagementSystem.Services.Interfaces.Models;

namespace RestaurantManagementSystem.Infrastructure.Repositories
{
    /// <summary>
    /// User Repository
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IAppSettings _appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="context">Instance of <see cref="MongoContext"/></param>
        public UserRepository(IMongoContext context, IAppSettings appSettings) : base(context)
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Find the user with a valid password
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Passowrd</param>
        /// <returns>A <see cref="Task"/> of type <see cref="User"/> or null</returns>
        public async Task<User> FindAsync(string email, string password)
        {
            var user = await FindAsyncByEmail(email);

            if (user != null) 
            { 
                bool validPassword = AesCryptographyHelper.DecryptString(user.Password, _appSettings.AesKey) == password;
                if (validPassword)
                    return user;
            }

            return null;
        }

        /// <summary>
        /// Find the user
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>A <see cref="Task"/> of type <see cref="User"/> or null</returns>
        public async Task<User> FindAsyncByEmail(string email)
        {
            var filter = Builders<User>.Filter.Where(user => user.Email == email);
            var find = await Collection.FindAsync<User>(filter);
            return find.FirstOrDefault();
        }
    }
}
