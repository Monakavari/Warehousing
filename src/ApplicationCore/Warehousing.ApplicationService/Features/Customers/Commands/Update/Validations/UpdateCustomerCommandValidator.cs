using FluentValidation;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;

namespace Warehousing.ApplicationService.Features.Customers.Commands.Update.Validations
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(current => current.Id)
                  .NotNull()
                  .WithMessage("{PropertyId} can not be null")
                  .GreaterThan(0)
                  .WithMessage("{PropertyId} must greater than {ComparisonValue}");

            RuleFor(current => current.CustomerName)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("{PropertyCustomerName} can not be null")
                   .MaximumLength(50)
                   .WithMessage("{PropertyCustomerName} can not be greater than {0}");

            RuleFor(current => current.WarehouseId)
                   .NotNull()
                   .WithMessage("{PropertyWarehouseId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyWarehouseId} must greater than {ComparisonValue}");

            RuleFor(current => current.CustomerTel)
                   .NotNull()
                   .WithMessage("{PropertyCustomerTel} can not be null")
                   .Length(11)
                   .WithMessage("{PropertyCustomerTel} must be {ComparisonValue}");

            RuleFor(current => current.EconomicCode)
                  .NotEmpty()
                  .NotNull()
                  .WithMessage("{PropertyEconomicCode} can not be null")
                  .Length(11)
                  .WithMessage("{PropertyEconomicCode} must be {ComparisonValue}");

            RuleFor(current => current.CustomerAddress)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("{PropertyCustomerAddress} can not be null")
                   .MaximumLength(100)
                   .WithMessage("{PropertyCustomerAddress} must be {0}");

        }
    }
}
