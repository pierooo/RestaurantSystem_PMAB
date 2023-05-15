using MediatR;
using RestaurantSystem.Contracts.Reservations.Queries;

namespace RestaurantSystem.Contracts.RestaurantTables.Queries;

public class GetRestaurantTableById : IRequest<GetRestaurantTableByIdResponse>
{
    public int Id { get; set; }
}