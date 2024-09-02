using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new restaurant");
            var restaurant = mapper.Map<Restaurant>(request);

            if (restaurant == null)
                throw new Exception("error");

            restaurant.IsActive = true; // IsActive permet de determiner si un restaurant existe vraiment.
            int id = await restaurantsRepository.CreateAsync(restaurant);

            return id;
        }
    }
}
