using RestaurantManagementSystem.Application.Models.Authentication;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using RestaurantManagementSystem.Services.Interfaces.Services.Authentication;
using System;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Services.Authentication
{
    /// <summary>
    /// Login Service
    /// </summary>
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginService"/> class
        /// </summary>
        /// <param name="userRepository">Instance of the user repository</param>
        /// <param name="tokenService">Instance of the token service</param>
        public LoginService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Checks if the user exists and generates the Authentication token
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        /// <returns>A <see cref="Task"/> of type <see cref="LoginResponseDTO"/></returns>
        public async Task<LoginResponseDTO> Login(string email, string password)
        {
            var user = await _userRepository.FindAsync(email, password);
            if (user == null)
                return null;

            var token = _tokenService.GenerateToken(user);
            return new LoginResponseDTO(token, user);
        }
    }
}
