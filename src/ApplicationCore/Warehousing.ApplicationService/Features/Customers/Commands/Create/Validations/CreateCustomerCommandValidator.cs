using FluentValidation;

namespace Warehousing.ApplicationService.Features.Inventory.Commands.Create.Validations
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {

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
