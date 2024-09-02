using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
   public record class GetRestaurantByIdQuery(int Id) : IRequest<RestaurantDto?>; 
}
