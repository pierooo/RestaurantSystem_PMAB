using FluentValidation;
using RestaurantSystem.Contracts.OrdersDetails.Commands;
using RestaurantSystem.Contracts.OrdersDetails.Queries;

namespace RestaurantSystem.Validators;

public class AddOrderDetailsCommandValidator : AbstractValidator<AddOrderDetailsCommand>
{
    public AddOrderDetailsCommandValidator()
    {
        RuleFor(x => x.OrderID).NotEmpty().GreaterThan(0);
        RuleFor(x => x.ProductID).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
    }
}

public class DeleteOrderDetailsCommandValidator : AbstractValidator<DeleteOrderDetailsCommand>
{
    public DeleteOrderDetailsCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
    }
}

public class UpdateOrderDetailsCommandValidator : AbstractValidator<UpdateOrderDetailsCommand>
{
    public UpdateOrderDetailsCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        RuleFor(x => x.ProductID).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
    }
}

public class GetOrderDetailsByIdValidator : AbstractValidator<GetOrderDetailsById>
{
    public GetOrderDetailsByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
    }
}