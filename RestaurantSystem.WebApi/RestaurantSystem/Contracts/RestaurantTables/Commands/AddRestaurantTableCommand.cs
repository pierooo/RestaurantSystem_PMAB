using MediatR;

namespace RestaurantSystem.Contracts.RestaurantTables.Commands;

public class AddRestaurantTableCommand : IRequest<AddRestaurantTableResponse>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int MaxCapacity { get; set; }

    public string? PhotoUrl { get; set; }
}
