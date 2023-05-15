namespace RestaurantSystem.Contracts;

public class CommandResponse
{
    public bool Done { get; }

    public CommandResponse(bool done)
    {
        Done = done;
    }
}
