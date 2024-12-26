using FluentValidation;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;

namespace Warehousing.ApplicationService.Features.Invoices.Commands.Create.Validations
{
    public class CreateInvoiceCommandValidators : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidators()
        {

            RuleFor(current => current.CustomerId)
                   .NotNull()
                   .WithMessage("{PropertyCustomerId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyCustomerId} must be greater than {ComparisonValue}");

            RuleFor(current => current.WarehouseId)
                   .NotNull()
                   .WithMessage("{PropertyWarehouseId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyWarehouseId} must be greater than {ComparisonValue}");

            RuleFor(current => current.FiscalYearId)
                   .NotNull()
                   .WithMessage("{PropertyFiscalYearId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyFiscalYearId} must be greater than {ComparisonValue}");

            //RuleFor(current => current.InvoiceProducts.ProductCount)
                  //.NotNull()
                  //.NotEmpty()
                  //.WithMessage("{PropertyMainProductCount} can not be null")
                 // .GreaterThan(0)
                  //.WithMessage("{PropertyMainProductCount} must be greater than {ComparisonValue}");
        }
    }
}
