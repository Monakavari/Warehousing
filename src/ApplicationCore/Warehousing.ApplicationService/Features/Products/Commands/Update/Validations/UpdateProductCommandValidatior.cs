using FluentValidation;

namespace Warehousing.ApplicationService.Features.Product.Commands.Update.Validations
{
    public class UpdateProductCommandValidatior:AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidatior()
        {
            RuleFor(c => c.Id)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyId} can not be null or empty")
              .GreaterThan(0)
             .WithMessage("{PropertyId} can not be Zero");
        }
    }
}
