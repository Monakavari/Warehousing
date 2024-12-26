using FluentValidation;

namespace Warehousing.ApplicationService.Features.Countries.Commands.Delete.Validations
{
    public class DeleteCountryCommandValidator : FluentValidation.AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(current => current.Id)
              .NotEmpty()
              .NotNull()
              .WithMessage("{PropertyId} can not be null")
              .GreaterThan(0)
              .WithMessage("{PropertyName} must greater than {ComparisonValue}");
        }
    }
}
