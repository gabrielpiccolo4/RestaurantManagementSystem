using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.Models.Authentication;
using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Services.Authentication;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Api.Controllers.Authentication
{
    /// <summary>
    /// Controller for the sign up service
    /// </summary>
    public class SignUpController : BaseController
    {
        private readonly ISignUpService _signUpService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpController"/> class
        /// </summary>
        /// <param name="signUpService">Instance of the Sign Up Service</param>
        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        /// <summary>
        /// Sign Up
        /// </summary>
        /// <param name="signUpRequestDTO">Instance of the <see cref="SignUpRequestDTO"/> class</param>
        /// <returns>An <see cref="ActionResult"/></returns>
        /// <response code="200">Account created successfully</response>
        /// <response code="303">Account already exists, login instead</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> Post(SignUpRequestDTO signUpRequestDTO)
        {
            var user = new User(signUpRequestDTO.Email, signUpRequestDTO.Name, signUpRequestDTO.Password);

            user = await _signUpService.SignUp(user);

            if (user == null)
                return StatusCode(303);

            return Ok();
        }
    }
}
