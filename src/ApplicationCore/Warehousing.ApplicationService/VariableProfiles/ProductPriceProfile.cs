using Warehousing.ApplicationService.Features.ProductPrice.Commands;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class ProductPriceProfile
    {
        public static ProductPrice Map(CreateProductPriceCommand command)
        {
            return new ProductPrice
            {
                ProductId = command.ProductId,
                FiscalYearId = command.FiscalYearId,
                ActionDate = PersianDate.ToMiladi(command.ActionDate),
                CoverPrice = command.CoverPrice,
                PurchasePrice = command.PurchasePrice,
                SalesPrice = command.SalesPrice,
            };
        }
        public static GetProductPriceResponseDto Map(ProductPrice command)
        {
            return new GetProductPriceResponseDto
            {
                ProductPriceId = command.Id,
                ProductId = command.ProductId,
                FiscalYearId = command.FiscalYearId,
                ActionDate = PersianDate.ToShamsi(command.ActionDate),
                CoverPrice = command.CoverPrice,
                PurchasePrice = command.PurchasePrice,
                SalesPrice = command.SalesPrice
            };
        }
    }
}
