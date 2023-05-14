namespace RestaurantSystem.Contracts;

public class ErrorModel
{
    public ErrorModel(string error)
    {
        this.Error = error;
    }
    public string Error { get; }
}
