using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.RestaurantTables.Queries;

public class GetRestaurantTableByIdResponse : IResponseBase
{
    public RestaurantTable? RestaurantTable { get; set; }
}
