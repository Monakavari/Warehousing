using FluentValidation;
using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.ProductLocation.Commands.Delete.Validations
{
    public class DeleteProductLocationCommandValidator:AbstractValidator<DeleteProductLocationCommand>
    {
        public DeleteProductLocationCommandValidator()
        {
            RuleFor(current => current.Id)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyId} can not be null")
                  .GreaterThan(0)
                  .WithMessage("{PropertyId} must greater than {ComparisonValue}");
        }
    }
}
