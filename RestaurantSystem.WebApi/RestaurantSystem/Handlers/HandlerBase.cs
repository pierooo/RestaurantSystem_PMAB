using RestaurantSystem.DataAccess;

namespace RestaurantSystem.Handlers;

public abstract class HandlerBase
{
    protected readonly RestaurantSystemContext restaurantSystemContext;

    public HandlerBase(RestaurantSystemContext restaurantSystemContext)
    {
        this.restaurantSystemContext = restaurantSystemContext;
    }
}
