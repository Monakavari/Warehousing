using FluentValidation;

namespace Warehousing.ApplicationService.Features.Warehouse.Commands.Update.Validations
{
    public class UpdateWarehouseCommandValidator :AbstractValidator<UpdateWarehouseCommand>
    {
        public UpdateWarehouseCommandValidator()
        {
            RuleFor(current => current.Id)
              .NotNull()
              .WithMessage("{PropertyId} can not be null")
              .GreaterThan(0)
              .WithMessage("{PropertyId} must greater than {ComparisonValue}");

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

