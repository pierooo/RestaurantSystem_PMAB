using FluentValidation;
using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.Contracts.Categories.Queries;

namespace RestaurantSystem.Validators;

public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(300);
    }
}

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(300);
    }
}

public class GetCategoryByIdValidator : AbstractValidator<GetCategoryById>
{
    public GetCategoryByIdValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}