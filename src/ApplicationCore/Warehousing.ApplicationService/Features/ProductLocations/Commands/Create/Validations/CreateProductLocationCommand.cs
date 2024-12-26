using FluentValidation;
using Warehousing.ApplicationService.Features.ProductLocation.Commands.Create;

namespace Warehousing.ApplicationService.Features.Inventory.Commands.Create.Validations
{
    public class CreateProductLocationCommandValidator : AbstractValidator<CreateProductLocationCommand>
    {
        public CreateProductLocationCommandValidator()
        {

            RuleFor(current => current.ProductLocationAddress)
                   .NotNull()
                   .NotEmpty()
                   .WithMessage("{PropertyProductLocationAddress} can not be null");
         
            RuleFor(current => current.WarehouseId)
                   .NotNull()
                   .NotEmpty()
                   .WithMessage("{PropertyWarehouseId} can not be null")
                   .GreaterThan(0)
                   .WithMessage("{PropertyWarehouseId} must greater than {ComparisonValue}");
        }
    }
}
