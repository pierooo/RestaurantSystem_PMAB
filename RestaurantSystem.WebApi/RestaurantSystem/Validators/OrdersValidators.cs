using FluentValidation;
using RestaurantSystem.Contracts.Orders.Commands;
using RestaurantSystem.Contracts.Orders.Queries;

namespace RestaurantSystem.Validators;

public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
{
    public AddOrderCommandValidator()
    {
        RuleFor(x => x.RestaurantTableID).NotEmpty().GreaterThan(0);
    }
}

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
    }
}

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.RestaurantTableID).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
    }
}

public class GetOrderByIdValidator : AbstractValidator<GetOrderById>
{
    public GetOrderByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
    }
}
