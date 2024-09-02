using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Command.CreateRestaurant
{
    public class CreateRestaurantCommand :IRequest<int>
    {
        public string Name { get; set; } = default!; // Required property 
        public string Description { get; set; } = default!;  // Required Property 
        public string Category { get; set; } = default!; // Required Property
        public bool HasDelivery { get; set; }
        public bool IsActive { get; set; }



        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
    }
}
