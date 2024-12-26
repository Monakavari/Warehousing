using FluentValidation;
using System.Resources;

namespace Warehousing.ApplicationService.Features.Countries.Commands.Update.Validations
{
    public class UpdateCountryCommandValidator : FluentValidation.AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryCommandValidator()
        {
            RuleFor(current => current.CountryName)
                .NotNull()
                .WithMessage("{PropertyName} can not be null")
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty")
                .MaximumLength(100)
                .WithMessage("{PropertyName} can not be grater {0}");

            RuleFor(current => current.Id)
                .NotNull()
                .WithMessage("{PropertyId} can not be null")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must greater than {ComparisonValue}");

        }
    }
}
