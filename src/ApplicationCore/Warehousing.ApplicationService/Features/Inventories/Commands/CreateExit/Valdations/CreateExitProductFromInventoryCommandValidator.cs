using FluentValidation;

namespace Warehousing.ApplicationService.Features.Inventory.Commands.CreateExit.Valdations
{
    public class CreateExitProductFromInventoryCommandValidator:AbstractValidator<CreateExitProductFromInventoryCommand>
    {
        public CreateExitProductFromInventoryCommandValidator()
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

            RuleFor(current => current.RefferenceInventoryId)
                   .NotNull()
                   .WithMessage("{PropertyRefferenceInventoryId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyRefferenceInventoryId} must greater than {ComparisonValue}");

            RuleFor(c => c.Description)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyFiscalYearDescription} can not be null or empty")
                  .MaximumLength(100)
                  .WithMessage("{PropertyEndDate} can not be greater than {0}");

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
