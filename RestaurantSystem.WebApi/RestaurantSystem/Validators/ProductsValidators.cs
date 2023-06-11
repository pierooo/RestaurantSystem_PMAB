using FluentValidation;
using RestaurantSystem.Contracts.Products.Commands;
using RestaurantSystem.Contracts.Products.Queries;

namespace RestaurantSystem.Validators;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.CategoryID).GreaterThan(0);
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(300);
        RuleFor(c => c.UnitPriceGross).NotEmpty().GreaterThan(0);
        RuleFor(c => c.VAT).NotEmpty().GreaterThan(0);
    }
}

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.CategoryID).GreaterThan(0);
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(300);
        RuleFor(c => c.UnitPriceGross).NotEmpty().GreaterThan(0);
        RuleFor(c => c.VAT).NotEmpty().GreaterThan(0);
    }
}

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}

public class GetProductByIdValidator : AbstractValidator<GetProductById>
{
    public GetProductByIdValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
