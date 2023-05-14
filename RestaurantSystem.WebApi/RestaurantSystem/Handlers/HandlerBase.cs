using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers;

public abstract class HandlerBase
{
    protected readonly RestaurantSystemContext RestaurantSystemContext;

    public HandlerBase(RestaurantSystemContext restaurantSystemContext)
    {
        RestaurantSystemContext = restaurantSystemContext;
    }
}
