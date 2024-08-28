using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    public class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();

            var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants); ;

            return restaurantDtos!;
        }

        public async Task<RestaurantDto?> GetRestaurantById(int id)
        {
            logger.LogInformation("Getting single restaurant");
            var restaurant = await restaurantsRepository.GetByIdAsync(id);

            var restaurantDto =  mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }
    }
}
