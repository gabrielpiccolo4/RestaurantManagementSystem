using RestaurantManagementSystem.Application.Models.Authentication;
using RestaurantManagementSystem.Common.Enums;
using RestaurantManagementSystem.Services.Entities;
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
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginService"/> class
        /// </summary>
        /// <param name="userRepository">Instance of the user repository</param>
        /// <param name="tokenService">Instance of the token service</param>
        public SignUpService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
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

            await _userRepository.InsertAsync(newUser);

            return newUser;
        }
    }
}
