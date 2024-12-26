using FluentValidation;

namespace Warehousing.ApplicationService.Features.Countries.Commands.Create.Validations
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(c => c.CountryName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("{PropertyName} can not be null");
        }
    }
}
