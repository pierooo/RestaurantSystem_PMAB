using MediatR;

namespace RestaurantSystem.Contracts.RestaurantTables.Commands;

public class DeleteRestaurantTableCommand : IRequest<DeleteRestaurantTableResponse>
{
    public int Id { get; set; }
}

