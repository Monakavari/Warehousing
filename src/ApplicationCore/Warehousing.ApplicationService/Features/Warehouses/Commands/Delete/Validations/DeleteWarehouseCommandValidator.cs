using FluentValidation;

namespace Warehousing.ApplicationService.Features.Warehouse.Commands.Delete.Validations
{
    public class DeleteWarehouseCommandValidator : AbstractValidator<DeleteWarehouseCommand>
    {
        public DeleteWarehouseCommandValidator()
        {
            RuleFor(current => current.Id)
               .NotNull()
               .WithMessage("{PropertyId} can not be null")
               .GreaterThan(0)
               .WithMessage("{PropertyId} must greater than {ComparisonValue}");
        }
    }
}
