using FluentValidation;
using Warehousing.ApplicationService.Features.ProductPrice.Commands;

namespace Warehousing.ApplicationService.Features.Inventory.Commands.Create.Validations
{
    public class AddProductStockCommandValidator : AbstractValidator<AddProductStockCommand>
    {
        public AddProductStockCommandValidator()
        {

            RuleFor(current => current.ProductId)
                   .NotNull()
                   .WithMessage("{PropertyProductId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyProductId} must greater than {ComparisonValue}");

            RuleFor(current => current.WarehouseId)
                   .NotNull()
                   .WithMessage("{PropertyWarehouseId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyWarehouseId} must greater than {ComparisonValue}");

            RuleFor(current => current.FiscalYearId)
                   .NotNull()
                   .WithMessage("{PropertyFiscalYearId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyFiscalYearId} must greater than {ComparisonValue}");

            RuleFor(current => current.ProductLocationId)
                  .NotNull()
                  .WithMessage("{PropertyProductLocationId} can not be null")
                  .GreaterThan(0)
                  .WithMessage("{PropertyProductLocationId} must greater than {ComparisonValue}");

            RuleFor(current => current.RefferenceID)
                   .NotNull()
                   .WithMessage("{PropertyRefferenceID} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyRefferenceID} must greater than {ComparisonValue}");

            RuleFor(c => c.Description)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyDescription} can not be null or empty")
                  .MaximumLength(100)
                  .WithMessage("{PropertyDescription} can not be greater than {0}");

            RuleFor(current => current.MainProductCount)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyMainProductCount} can not be null")
                  .GreaterThan(0)
                  .WithMessage("{PropertyMainProductCount} must greater than {ComparisonValue}");

            RuleFor(current => current.WastageProductCount)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyWastageProductCount} can not be null");
        }
    }
}
