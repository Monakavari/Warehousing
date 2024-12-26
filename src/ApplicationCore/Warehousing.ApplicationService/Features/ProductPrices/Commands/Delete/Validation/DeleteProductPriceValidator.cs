using FluentValidation;
using Microsoft.Extensions.Hosting;

namespace Warehousing.ApplicationService.Features.ProductPrice.Commands.Delete.Validation
{
    public class DeleteProductPriceValidator :AbstractValidator<DeleteProductPriceCommand>
    {
        public DeleteProductPriceValidator()
        {

            RuleFor(current => current.Id)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyId} can not be null or empty")
                  .GreaterThan(0)
                  .WithMessage("{PropertyName} must greater than {ComparisonValue}");
        }
    }
}
