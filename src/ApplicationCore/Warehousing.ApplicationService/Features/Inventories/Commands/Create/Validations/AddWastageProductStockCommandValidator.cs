using FluentValidation;

namespace Warehousing.ApplicationService.Features.Inventory.Commands.Create.Validations
{
    public class AddWastageProductStockCommandValidator:AbstractValidator<AddWastageProductStockCommand>
    {
        public AddWastageProductStockCommandValidator()
        {
            RuleFor(current => current.WastageProductId)
                  .NotNull()
                  .WithMessage("{PropertyWastageProductId} can not be null")
                  .GreaterThan(0)
                  .WithMessage("{PropertyWastageProductId} must greater than {ComparisonValue}");

            RuleFor(current => current.WastageWarehouseId)
                   .NotNull()
                   .WithMessage("{PropertyWastageWarehouseId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyWastageWarehouseId} must greater than {ComparisonValue}");

            RuleFor(current => current.WastageFiscalYearId)
                   .NotNull()
                   .WithMessage("{PropertyWastageFiscalYearId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyWastageFiscalYearId} must greater than {ComparisonValue}");

            RuleFor(current => current.WastageProductLocationId)
                  .NotNull()
                  .WithMessage("{PropertyWastageProductLocationId} can not be null")
                  .GreaterThan(0)
                  .WithMessage("{PropertyWastageProductLocationId} must greater than {ComparisonValue}");

            RuleFor(current => current.WastageInvRefferenceId)
                   .NotNull()
                   .WithMessage("{PropertyWastageRefferenceId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyWastageRefferenceId} must greater than {ComparisonValue}");

            RuleFor(c => c.WastageDescription)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyWastageDescription} can not be null or empty")
                  .MaximumLength(100)
                  .WithMessage("{PropertyWastageDescription} can not be greater than {0}");

            RuleFor(current => current.WastageProductCount)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyWastageProductCount} can not be null");
        }
    }
}
