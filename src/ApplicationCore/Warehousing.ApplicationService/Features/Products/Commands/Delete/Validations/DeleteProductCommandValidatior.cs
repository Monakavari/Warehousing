using FluentValidation;

namespace Warehousing.ApplicationService.Features.Product.Commands.Delete.Validations
{
    public class DeleteProductCommandValidatior:AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidatior()
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
