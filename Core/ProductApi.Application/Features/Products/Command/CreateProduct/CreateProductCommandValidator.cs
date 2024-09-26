using FluentValidation;

namespace ProductApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.BrandId).GreaterThan(0).WithName("Brand");

            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithName("Discount Ratio");

            RuleFor(x => x.CategoryIds).NotEmpty().Must(categories => categories.Any()).WithName("Categories");


        }
    }
}
