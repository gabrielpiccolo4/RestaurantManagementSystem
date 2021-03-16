using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Api.Attributes;
using RestaurantManagementSystem.Common.Enums;
using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Api.Controllers
{
    /// <summary>
    /// Controller for the restaurants service
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    //[RoleAuthorize(Roles.Admin, Roles.User)]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantController"/> class
        /// </summary>
        /// <param name="restaurantService">Instance of the restaurant service</param>
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        /// <summary>
        /// Gets a restaurant by id
        /// </summary>
        /// <param name="id">The id of the restaurant</param>
        /// <returns>An <see cref="ActionResult"/> of type <see cref="Restaurant"/></returns>
        /// <response code="200">Returns the requested restaurant</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:length(24)}", Name = "GetRestaurant")]
        public async Task<ActionResult<Restaurant>> Get(string id)
        { 
            var restaurant = await _restaurantService.GetById(id);

            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }

        /// <summary>
        /// Gets all the restaurants
        /// </summary>
        /// <returns>Returns all restaurants</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Name = "GetAllRestaurants")]
        public async Task<ActionResult<List<Restaurant>>> Get()
        {
            var restaurants = await _restaurantService.GetAll();

            if (!restaurants.Any())
                return NotFound();

            return Ok(restaurants);
        }
    }
}
