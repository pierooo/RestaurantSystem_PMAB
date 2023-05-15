namespace RestaurantSystem.Contracts.Entities;

public class RestaurantTable
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int MaxCapacity { get; set; }

    public string? PhotoUrl { get; set; }
}
