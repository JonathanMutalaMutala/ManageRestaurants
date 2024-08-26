using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!; // Required property 
        public string Description { get; set; } = default!;  // Required Property 
        public string Category { get; set; } = default!; // Required Property
        public bool HasDelivery { get; set; } 
        public bool IsActive { get; set; }
        


        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        public Address? Address { get; set; }
        public List<Dish> Dishes { get; set; } = new List<Dish>(); 
    }
}
