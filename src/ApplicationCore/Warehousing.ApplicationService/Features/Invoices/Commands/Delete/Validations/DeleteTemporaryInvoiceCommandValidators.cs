using FluentValidation;
using FluentValidation.Validators;
using Warehousing.ApplicationService.Features.Invoices.Commands.Create;

namespace Warehousing.ApplicationService.Features.Invoices.Commands.Delete.Validations
{
    public class DeleteTemporaryInvoiceCommandValidators : AbstractValidator<DeleteTemporaryInvoiceCommand>
    {
        public DeleteTemporaryInvoiceCommandValidators()
        {
            RuleFor(current => current.InvoiceId)
                   .NotNull()
                   .WithMessage("{PropertyInvoiceId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyInvoiceId} must be greater than {ComparisonValue}");
        }
    }
}
