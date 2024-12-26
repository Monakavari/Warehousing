using FluentValidation;

namespace Warehousing.ApplicationService.Features.Invoices.Commands.Create.Validations
{
    public class SetInvoiceToCloseCommandValidator : AbstractValidator<SetInvoiceToCloseCommand>
    {
        public SetInvoiceToCloseCommandValidator()
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
