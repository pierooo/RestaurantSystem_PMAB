using MediatR;

namespace RestaurantSystem.Contracts.RestaurantTables.Commands;

public class DeleteRestaurantTableCommand : IRequest<CommandResponse>
{
    public int Id { get; set; }
}

