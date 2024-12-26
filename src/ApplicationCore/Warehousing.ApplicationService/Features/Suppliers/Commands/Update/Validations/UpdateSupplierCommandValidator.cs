using FluentValidation;

namespace Warehousing.ApplicationService.Features.Suppliers.Commands.Update.Validation
{
    public class UpdatesupplierCommandValidator:AbstractValidator<UpdateSupplierCommand>
    {
        public UpdatesupplierCommandValidator()
        {
            RuleFor(current => current.Id)
                  .NotNull()
                  .WithMessage("{PropertyId} can not be null")
                  .GreaterThan(0)
                  .WithMessage("{PropertyName} must greater than {ComparisonValue}");

            RuleFor(c => c.SupplierName)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} can not be null or empty")
               .MaximumLength(100)
               .WithMessage("{PropertyName} can not be greater than {0}");

            RuleFor(c => c.SupplerTel)
              .NotNull()
              .NotEmpty()
              .WithMessage("{SupplerTel} can not be null or empty")
              .MaximumLength(8)
              .WithMessage("{PropertyTel} must not greater than {ComparisonValue}");

            RuleFor(c => c.SupplerWebsite)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyNameWebsite} can not be null or empty")
              .MaximumLength(50)
              .WithMessage("{PropertyNameWebsite} must not be greater than {ComparisonValue}");
        }
    }
}
