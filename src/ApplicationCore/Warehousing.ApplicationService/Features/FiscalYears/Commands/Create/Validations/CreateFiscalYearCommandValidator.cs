using FluentValidation;
using FluentValidation.Validators;

namespace Warehousing.ApplicationService.Features.FiscalYear.Commands.Create.Validations
{
    public class CreateFiscalYearCommandValidator : AbstractValidator<CreateFiscalYearCommand>
    {
        public CreateFiscalYearCommandValidator()
        {
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
              .WithMessage("{PropertyFiscalYearDescription} can not be greater than {0}");
        }
    }
}
