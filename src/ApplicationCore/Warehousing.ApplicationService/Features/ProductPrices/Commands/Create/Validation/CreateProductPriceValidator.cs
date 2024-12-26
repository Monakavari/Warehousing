using FluentValidation;

namespace Warehousing.ApplicationService.Features.ProductPrice.Commands.Create.Validation
{
    public class CreateProductPriceValidator : AbstractValidator<CreateProductPriceCommand>
    {
        public CreateProductPriceValidator()
        {
            RuleFor(c => c.PurchasePrice)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyPurchasePrice} can not be null or empty")
              .GreaterThan(0)
              .WithMessage("{PropertyPurchasePrice} can not be Zero");

            RuleFor(c => c.SalesPrice)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyPurchasePrice} can not be null or empty")
               .GreaterThan(0)
               .WithMessage("{PropertyPurchasePrice} can not be Zero");

            RuleFor(c => c.CoverPrice)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyCoverPrice} can not be null or empty")
               .GreaterThan(0)
               .WithMessage("{PropertyCoverPrice} can not be Zero");

            RuleFor(c => c.ProductId)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyProductId} can not be null or empty")
               .GreaterThan(0)
               .WithMessage("{PropertyProductId} can not be Zero");


            RuleFor(c => c.FiscalYearId)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyFiscalYearId} can not be null or empty")
              .GreaterThan(0)
              .WithMessage("{PropertyFiscalYearId} can not be Zero");

            RuleFor(c => c.ActionDate)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyActionDate} can not be null or empty");
        }
    }
}
