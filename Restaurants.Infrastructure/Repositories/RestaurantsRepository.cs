using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository : IRestaurantsRepository
    {
        private readonly RestaurantsDbContext _dbContext;

        public RestaurantsRepository(RestaurantsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
           await _dbContext.SaveChangesAsync();

            return restaurant.Id;
        }

        public async Task Delete(Restaurant entity)
        {
            entity.IsActive = false;
            _dbContext.Restaurants.Update(entity); 
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await _dbContext.Restaurants
                .Include(x => x.Dishes)
                .ToListAsync();

            return restaurants;
        }

        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            var restaurant = await _dbContext.Restaurants
                .Include(x => x.Dishes)
                .FirstOrDefaultAsync(x => x.Id == id);

            return restaurant;
        }
    }
}
