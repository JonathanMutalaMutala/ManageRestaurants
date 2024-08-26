using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfranstructure(this IServiceCollection services)
        {
            services.AddDbContext<RestaurantsDbContext>();
        }
    }
}
