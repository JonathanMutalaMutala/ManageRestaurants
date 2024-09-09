using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository : IDishesRepository
    {
        private readonly RestaurantsDbContext _dbContext;

        public DishesRepository(RestaurantsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Dish dish)
        {
           _dbContext.Dishes.Add(dish);
           await _dbContext.SaveChangesAsync();

            return dish.Id; 
        }
    }
}
