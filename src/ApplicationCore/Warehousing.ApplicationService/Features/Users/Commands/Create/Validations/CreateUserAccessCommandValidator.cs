using FluentValidation;

namespace Warehousing.ApplicationService.Features.Users.Commands.Create.Validations
{
    public class CreateUserAccessCommandValidator : AbstractValidator<CreateUserAccessCommand>
    {
        public CreateUserAccessCommandValidator()
        {
            RuleFor(current => current.UserIdAccess)
               .NotNull()
               .NotEmpty()
               .WithMessage("{UserIdAccess} can not be null");
        }
    }
}
