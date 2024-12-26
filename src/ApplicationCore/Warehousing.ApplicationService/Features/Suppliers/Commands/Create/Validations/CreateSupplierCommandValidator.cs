using FluentValidation;

namespace Warehousing.ApplicationService.Features.Suppliers.Commands.Create.Validations
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
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
