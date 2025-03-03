﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfranstructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("RestaurantsConnectionString"));
            });
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddTransient<IRestaurantsRepository, RestaurantsRepository>();
            services.AddTransient<IDishesRepository, DishesRepository>();
        }
    }
}
