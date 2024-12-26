using FluentValidation;

namespace Warehousing.ApplicationService.Features.Product.Commands.Create.Validations
{
    public class CreateProductCommandValidatior:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidatior()
        {
            RuleFor(c => c.ProductName)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyProductName} can not be null or empty")
               .MaximumLength(100)
               .WithMessage("{PropertyProductName} can not be greater than {0}");

            RuleFor(c => c.ProductCode)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyProductCode} can not be null or empty")
               .MaximumLength(100)
               .WithMessage("{PropertyProductCode} can not be greater than {0}");

            RuleFor(c => c.PackingType.ToString())
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyPackingType} can not be null or empty");

            RuleFor(c => c.CountInPacking)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyCountInPacking} can not be null or empty")
               .GreaterThan(0)
               .WithMessage("{PropertyCountInPacking} can not be Zero");


            RuleFor(c => c.ProductWeight)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyProductWeight} can not be null or empty")
              .GreaterThan(0)
              .WithMessage("{PropertyProductWeight} can not be Zero");

            RuleFor(c => c.ProductImage)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyProductImage} can not be null or empty");

            RuleFor(c => c.IsRefregrator)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyIsRefregrator} can not be null or empty");

            RuleFor(c => c.SupplierId)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertySupplierId} can not be null or empty")
               .GreaterThan(0)
              .WithMessage("{PropertySupplierId} can not be Zero");

            RuleFor(c => c.CountryId)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyCountryId} can not be null or empty")
              .GreaterThan(0)
             .WithMessage("{PropertyCountryId} can not be Zero");

        }
    }
}
