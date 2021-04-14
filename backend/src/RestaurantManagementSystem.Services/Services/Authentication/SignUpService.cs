using RestaurantManagementSystem.Common.Helpers;
using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Data;
using RestaurantManagementSystem.Services.Interfaces.Models;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using RestaurantManagementSystem.Services.Interfaces.Services.Authentication;
using System;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Services.Authentication
{
    /// <summary>
    /// Sign Up Service
    /// </summary>
    public class SignUpService : ISignUpService
    {
        private readonly IMongoContext _mongoContext;
        private readonly IUserRepository _userRepository;
        private readonly IAppSettings _appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpService"/> class
        /// </summary>
        /// <param name="mongoContext">Instance of the database context</param>
        /// <param name="userRepository">Instance of the user repository</param>
        /// <param name="appSettings">Instance of the app settings</param>
        public SignUpService(IMongoContext mongoContext, IUserRepository userRepository, IAppSettings appSettings)
        {
            _mongoContext = mongoContext;
            _userRepository = userRepository;
            _appSettings = appSettings;
        }

        public async Task<User> SignUp(User newUser)
        {
            var userExists = await _userRepository.FindAsyncByEmail(newUser.Email);
            if (userExists != null)
                return null;

            newUser.Password = AesCryptographyHelper.EncryptString(newUser.Password, _appSettings.AesKey);

            using (var session = await _mongoContext.MongoClient.StartSessionAsync())
            {
                session.StartTransaction();
                await _userRepository.InsertAsync(session, newUser);
                await session.CommitTransactionAsync();
            }

            return newUser;
        }
    }
}
