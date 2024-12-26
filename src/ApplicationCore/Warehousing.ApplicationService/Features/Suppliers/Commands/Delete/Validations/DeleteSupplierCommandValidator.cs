using FluentValidation;

namespace Warehousing.ApplicationService.Features.Suppliers.Commands.Delete.Validations
{
    public class DeleteSupplierCommandValidator :AbstractValidator<DeleteSupplierCommand>
    {
        public DeleteSupplierCommandValidator()
        {
            RuleFor(current => current.Id)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyId} can not be null or empty")
                  .GreaterThan(0)
                  .WithMessage("{PropertyName} must greater than {ComparisonValue}");
        }
    }
}
