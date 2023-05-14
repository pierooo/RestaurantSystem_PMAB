using MediatR;

namespace RestaurantSystem.Contracts.Categories.Queries;

public class GetCategoryById : IRequest<GetCategoryByIdResponse>
{
    public int Id { get; set; }
}
