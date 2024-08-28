using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantsService _restaurantsService;

        public RestaurantsController(IRestaurantsService restaurantsService)
        {
            this._restaurantsService = restaurantsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _restaurantsService.GetAllRestaurants());
        }
    }
}
