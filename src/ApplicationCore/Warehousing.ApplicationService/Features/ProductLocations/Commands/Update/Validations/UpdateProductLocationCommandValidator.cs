using FluentValidation;

namespace Warehousing.ApplicationService.Features.ProductLocation.Commands.Update.Validations
{
    public class UpdateProductLocationCommandValidator :AbstractValidator<UpdateProductLocationCommand>
    {
        public UpdateProductLocationCommandValidator()
        {
            RuleFor(current => current.Id)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyId} can not be null")
                  .GreaterThan(0)
                  .WithMessage("{PropertyId} must greater than {ComparisonValue}");

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
