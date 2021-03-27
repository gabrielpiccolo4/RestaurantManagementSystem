using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagementSystem.Api.Controllers
{
    /// <summary>
    /// Abstract class for the Controllers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase { }
}
