using FluentValidation;

namespace Warehousing.ApplicationService.Features.FiscalYear.Commands.Delete.Validations
{
    public class DeleteFiscalYearCommandValidator:AbstractValidator<DeleteFiscalYearCommand>
    {
        public DeleteFiscalYearCommandValidator()
        {
            RuleFor(current => current.Id)
                   .NotNull()
                   .WithMessage("{PropertyId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyId} must greater than {ComparisonValue}");
        }
    }
}
