using FluentValidation;
using Warehousing.ApplicationService.Features.Users.Commands.Delete;

namespace Warehousing.ApplicationService.Features.Suppliers.Commands.Delete.Validations
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(current => current.Id)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyId} can not be null or empty");
        }
    }
}
