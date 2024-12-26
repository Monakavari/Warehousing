using FluentValidation;
using Warehousing.ApplicationService.Features.Users.Commands.Update;

namespace Warehousing.ApplicationService.Features.Suppliers.Commands.Update.Validation
{
    public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(current => current.UserIdInWarehouse)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyId} can not be null");

            RuleFor(current => current.UserWarehouseId)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{WarehouseIds} can not be null");

            RuleFor(c => c.FirstName)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyName} can not be null or empty")
              .MaximumLength(100)
              .WithMessage("{PropertyName} can not be greater than {0}");

            RuleFor(c => c.LastName)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyLastName} can not be null or empty")
              .MaximumLength(100)
              .WithMessage("{PropertyLastName} must not greater than {ComparisonValue}");

            RuleFor(c => c.UserName)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyUserName} can not be null or empty")
              .MaximumLength(100)
              .WithMessage("{PropertyUserName} must not be greater than {ComparisonValue}");

            RuleFor(c => c.UserImage)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyUserImage} can not be null or empty");


            RuleFor(c => c.NationalCode)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyNationalCode} can not be null or empty")
              .MaximumLength(100)
              .WithMessage("{PropertyNationalCode} must not greater than {ComparisonValue}");


            RuleFor(c => c.PersonalCode)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyPersonalCode} can not be null or empty")
              .MaximumLength(100)
              .WithMessage("{PropertyPersonalCode} must not greater than {ComparisonValue}");


            RuleFor(c => c.PhoneNumber)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyPhoneNumber} can not be null or empty")
              .MaximumLength(11)
              .WithMessage("{PropertyPhoneNumber} must not greater than {ComparisonValue}");


            RuleFor(c => c.Gender)
             .NotNull()
             .NotEmpty()
             .WithMessage("{PropertyGender} can not be null or empty");


            //RuleFor(c => c.UserType)
            // .NotNull()
            // .NotEmpty()
            // .WithMessage("{PropertyUserType} can not be null or empty");
        }
    }
}
