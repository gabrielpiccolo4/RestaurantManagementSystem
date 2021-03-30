using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Models.Authentication;
using RestaurantManagementSystem.Services.Interfaces.Services.Authentication;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Api.Controllers.Authentication
{
    /// <summary>
    /// Controller for the login service
    /// </summary>
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class
        /// </summary>
        /// <param name="loginService">Instance of the Login Service</param>
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginRequest">Instance of the <see cref="LoginRequestDTO"/> class</param>
        /// <returns>An <see cref="ActionResult"/> of type <see cref="LoginResponseDTO"/></returns>
        /// <response code="200">Logged in successfully</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> Post(LoginRequestDTO loginRequest)
        {
            var loginResponse = await _loginService.Login(loginRequest.Email, loginRequest.Password);

            if (loginResponse == null)
                return Unauthorized();

            return Ok(loginResponse);
        }
    }
}
