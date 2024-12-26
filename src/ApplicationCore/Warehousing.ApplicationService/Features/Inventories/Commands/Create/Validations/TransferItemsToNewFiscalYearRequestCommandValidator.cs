using FluentValidation;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;

namespace Warehousing.ApplicationService.Features.Inventories.Commands.Create.Validations
{
    public class TransferItemsToNewFiscalYearRequestCommandValidator : AbstractValidator<TransferItemsToNewFiscalYearRequestCommand>
    {
        public TransferItemsToNewFiscalYearRequestCommandValidator()
        {
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

            RuleFor(current => current.UserId)
                   .NotNull()
                   .WithMessage("{PropertyUserId} can not be null")
                   //.GreaterThan(0)
                   .WithMessage("{PropertyUserId} must greater than {ComparisonValue}");
        }
    }
}
