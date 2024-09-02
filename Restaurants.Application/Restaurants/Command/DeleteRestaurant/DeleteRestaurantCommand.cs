using MediatR;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Command.DeleteRestaurant
{
    public record class DeleteRestaurantCommand(int Id) : IRequest<bool>;
}
