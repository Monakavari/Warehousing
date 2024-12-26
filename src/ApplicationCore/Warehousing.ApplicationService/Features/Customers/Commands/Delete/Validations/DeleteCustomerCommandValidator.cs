using FluentValidation;
using Warehousing.ApplicationService.Features.Customers.Commands.Update;

namespace Warehousing.ApplicationService.Features.Customers.Commands.Delete.Validations
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator() 
        {
            RuleFor(current => current.Id)
                      .NotNull()
                      .WithMessage("{PropertyId} can not be null")
                      .GreaterThan(0)
                      .WithMessage("{PropertyId} must greater than {ComparisonValue}");

        }
    }
}
