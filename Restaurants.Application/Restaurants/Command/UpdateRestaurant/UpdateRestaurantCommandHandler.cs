using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Command.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand,bool>
    {
        private readonly ILogger<UpdateRestaurantCommandHandler> logger;
        private IMapper mapper;
        private IRestaurantsRepository restaurantsRepository;

        public UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.restaurantsRepository = restaurantsRepository;
        }

        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating restaurant with id {request.Id}");
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
                return false;

            mapper.Map(request, restaurant); 
            return true; 
        }
    }
}
