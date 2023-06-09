using RestaurantSystem.Contracts.Entities;

namespace RestaurantSystem.Contracts.RestaurantTables.Queries;

public class GetRestaurantTablesResponse : IResponseBase
{
    public IReadOnlyCollection<RestaurantTable>? RestaurantTables { get; set; }
}
