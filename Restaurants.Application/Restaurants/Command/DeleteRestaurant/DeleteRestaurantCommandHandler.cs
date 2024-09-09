using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Command.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        private readonly ILogger<DeleteRestaurantCommandHandler> logger;
        private IMapper mapper;
        private IRestaurantsRepository restaurantsRepository;

        public DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.restaurantsRepository = restaurantsRepository;
        }

        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Delete restaurant");

            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
                throw new NotFoundException($"Restaurant with {request.Id} doesn't exist"); 

            await restaurantsRepository.Delete(restaurant);

            return true;
        }

    }
}
