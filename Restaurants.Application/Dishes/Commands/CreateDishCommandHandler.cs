using AutoMapper;
using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;


namespace Restaurants.Application.Dishes.Commands
{
    public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand>
    {
        private readonly IRestaurantsRepository RestaurantsRepository;
        private readonly IDishesRepository DishesRepository;
        private readonly IMapper Mapper;
        public CreateDishCommandHandler(IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository, IMapper mapper)
        {
            RestaurantsRepository = restaurantsRepository;
            DishesRepository = dishesRepository;
            Mapper = mapper;
        }

        public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await RestaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null)
                throw new NotFoundException("Restaurant does not exist");

            var dish = Mapper.Map<Dish>(request); 

            await DishesRepository.CreateAsync(dish);
        }
    }
}
