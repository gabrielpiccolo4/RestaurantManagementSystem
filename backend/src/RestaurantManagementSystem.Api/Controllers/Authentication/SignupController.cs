using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Models.Authentication;
using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Services.Authentication;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Api.Controllers.Authentication
{
    /// <summary>
    /// Controller for the login service
    /// </summary>
    public class SignupController : BaseController
    {
        private readonly ISignUpService _signUpService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class
        /// </summary>
        /// <param name="signUpService">Instance of the Sign Up Service</param>
        public SignupController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="signUpRequestDTO">Instance of the <see cref="SignUpRequestDTO"/> class</param>
        /// <returns>An <see cref="ActionResult"/> of type <see cref="LoginResponseDTO"/></returns>
        /// <response code="200">Logged in successfully</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> Post(SignUpRequestDTO signUpRequestDTO)
        {
            var user = new User(signUpRequestDTO.Username, signUpRequestDTO.Password, signUpRequestDTO.Name, signUpRequestDTO.Email);

            user = await _signUpService.Signup(user);

            if (user == null)
                return RedirectToPage("login");

            return Ok(user);
        }
    }
}
