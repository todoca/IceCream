using FluentValidation;
using IceCream.Application.Dtos.Request;

namespace IceCream.Application.Validators.Category;

public class CategoryValidator : AbstractValidator<CategoryRequestDto>
{
	public CategoryValidator()
	{
		RuleFor(x => x.Name)
		.NotNull().WithMessage("The field {PropertyName} cannot be null")
		.NotEmpty().WithMessage("The field {PropertyName} cannot be empty");
    }
}
