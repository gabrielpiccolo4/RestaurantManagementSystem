using RestaurantManagementSystem.Common.Helpers;
using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Models;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using RestaurantManagementSystem.Services.Interfaces.Services.Authentication;
using System;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Services.Authentication
{
    /// <summary>
    /// Login Service
    /// </summary>
    public class SignUpService : ISignUpService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAppSettings _appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginService"/> class
        /// </summary>
        /// <param name="userRepository">Instance of the user repository</param>
        /// <param name="appSettings">Instance of the app settings</param>
        public SignUpService(IUserRepository userRepository, IAppSettings appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings;
        }

        public async Task<User> Signup(User newUser)
        {
            if (string.IsNullOrEmpty(newUser.Username))
                throw new ArgumentNullException(nameof(newUser.Username));

            if (string.IsNullOrEmpty(newUser.Email))
                throw new ArgumentNullException(nameof(newUser.Email));

            if (string.IsNullOrEmpty(newUser.Email))
                throw new ArgumentNullException(nameof(newUser.Name));

            if (string.IsNullOrEmpty(newUser.Email))
                throw new ArgumentNullException(nameof(newUser.Password));

            var userExists = await _userRepository.FindAsyncByEmail(newUser.Email);
            if (userExists != null)
                return null;

            newUser.Password = AesCryptographyHelper.EncryptString(newUser.Password, _appSettings.AesKey);

            await _userRepository.InsertAsync(newUser);

            return newUser;
        }
    }
}
