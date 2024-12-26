using FluentValidation;

namespace Warehousing.ApplicationService.Features.FiscalYear.Commands.Update.Validations
{
    public class UpdateFiscalYearCommandValidators :AbstractValidator<UpdateFiscalYearCommand>
    {
        public UpdateFiscalYearCommandValidators()
        {
            RuleFor(current => current.Id)
                   .NotNull()
                   .WithMessage("{PropertyId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyId} must greater than {ComparisonValue}");

            RuleFor(c => c.StartDate)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyStartDate} can not be null or empty")
               .MaximumLength(10)
               .WithMessage("{PropertyStartDate} can not be greater than {0}");

            RuleFor(c => c.EndDate)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyEndDate} can not be null or empty")
               .MaximumLength(10)
               .WithMessage("{PropertyEndDate} can not be greater than {0}");

            RuleFor(c => c.FiscalFlag)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyFiscalFlag} can not be null or empty");

            RuleFor(c => c.FiscalYearDescription)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyFiscalYearDescription} can not be null or empty")
              .MaximumLength(100)
              .WithMessage("{PropertyEndDate} can not be greater than {0}");
        }
    }
}
