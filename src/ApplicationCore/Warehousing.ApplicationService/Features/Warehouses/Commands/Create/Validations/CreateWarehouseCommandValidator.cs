using FluentValidation;

namespace Warehousing.ApplicationService.Features.Warehouse.Commands.Create.Validations
{
    public class CreateWarehouseCommandValidator : AbstractValidator<CreateWarehouseCommand>
    {
        public CreateWarehouseCommandValidator()
        {
            RuleFor(c => c.WarehouseName)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} can not be null or empty")
               .MaximumLength(100)
               .WithMessage("{PropertyName} can not be greater than {0}");

            RuleFor(c => c.WarehouseAddress)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyWarehouseAddress} can not be null or empty")
               .MaximumLength(200)
               .WithMessage("{PropertyWarehouseAddress} can not be greater than {0}");

            RuleFor(c => c.WarehouseTel)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyWarehouseTel} can not be null or empty")
               .MaximumLength(8)
               .WithMessage("{PropertyWarehouseTel} can not be greater than {0}");
        }
    }
}
