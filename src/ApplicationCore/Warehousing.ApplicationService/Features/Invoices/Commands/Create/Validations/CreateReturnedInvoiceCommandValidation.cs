using FluentValidation;

namespace Warehousing.ApplicationService.Features.Invoices.Commands.Create.Validations
{
    public class CreateReturnedInvoiceCommandValidation : AbstractValidator<CreateReturnedInvoiceCommand>
    {
        public CreateReturnedInvoiceCommandValidation()
        {

            RuleFor(current => current.InvoiceId)
                   .NotNull()
                   .WithMessage("{PropertyInvoiceId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyInvoiceId} must be greater than {ComparisonValue}");

            RuleFor(current => current.FiscalYearId)
                   .NotNull()
                   .WithMessage("{PropertyFiscalYearId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyFiscalYearId} must be greater than {ComparisonValue}");
        }
    }
}
