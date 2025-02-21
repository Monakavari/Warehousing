using FluentValidation;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;

namespace Warehousing.ApplicationService.Features.Inventories.Commands.Create.Validations
{
    public class CreateReturnedWastageProductCommandValidator : AbstractValidator<CreateReturnedWastageProductCommand>
    {
        public CreateReturnedWastageProductCommandValidator()
        {
            RuleFor(current => current.ReturnedWastageProductId)
                 .NotNull()
                 .WithMessage("{PropertyReturnedWastageProductId} can not be null")
                 .GreaterThan(0)
                 .WithMessage("{PropertyReturnedWastageProductId} must greater than {ComparisonValue}");

            RuleFor(current => current.ReturnedWastageWarehouseId)
                   .NotNull()
                   .WithMessage("{PropertyReturnedWastageWarehouseId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyReturnedWastageWarehouseId} must greater than {ComparisonValue}");

            RuleFor(current => current.ReturnedWastageFiscalYearId)
                   .NotNull()
                   .WithMessage("{PropertyReturnedWastageFiscalYearId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyReturnedWastageFiscalYearId} must greater than {ComparisonValue}");

            RuleFor(current => current.ReturnedWastageProductLocationId)
                  .NotNull()
                  .WithMessage("{PropertyReturnedWastageProductLocationId} can not be null")
                  .GreaterThan(0)
                  .WithMessage("{PropertyReturnedWastageProductLocationId} must greater than {ComparisonValue}");

            RuleFor(current => current.ReturnedWastageInvRefferenceId)
                   .NotNull()
                   .WithMessage("{PropertyReturnedWastageInvRefferenceId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyReturnedWastageInvRefferenceId} must greater than {ComparisonValue}");

            RuleFor(c => c.ReturnedWastageDescription)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyReturnedWastageDescription} can not be null or empty")
                  .MaximumLength(100)
                  .WithMessage("{PropertyReturnedWastageDescription} can not be greater than {0}");

            RuleFor(current => current.ReturnedWastageProductCount)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{ReturnedWastageProductCount} can not be null");
        }
    }
}
