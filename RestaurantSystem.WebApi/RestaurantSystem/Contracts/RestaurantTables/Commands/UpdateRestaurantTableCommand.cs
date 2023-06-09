using MediatR;

namespace RestaurantSystem.Contracts.RestaurantTables.Commands;

public class UpdateRestaurantTableCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int MaxCapacity { get; set; }

    public string? PhotoUrl { get; set; }
}
