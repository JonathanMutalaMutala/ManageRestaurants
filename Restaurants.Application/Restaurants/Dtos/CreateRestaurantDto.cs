namespace Restaurants.Application.Restaurants.Dtos;
public class CreateRestaurantDto
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

