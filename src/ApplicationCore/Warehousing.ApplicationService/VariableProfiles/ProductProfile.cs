using Warehousing.ApplicationService.Features.Product.Commands.Create;
using Warehousing.ApplicationService.Features.Product.Commands.Update;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class ProductProfile
    {
        public static Product Map(CreateProductCommand command)
        {
            return new Product
            {
                ProductName = command.ProductName,
                CountInPacking = command.CountInPacking,
                CountryId = command.CountryId,
                IsRefregrator = command.IsRefregrator,
                //CreatorUserId = command.CreatorUserId,
                PackingType = command.PackingType,
                ProductImage = command.ProductImage,
                ProductWeight = command.ProductWeight,
                SupplierId = command.SupplierId,
            };
        }
        public static GetProductResponseVM Map(Product product)
        {
            return new GetProductResponseVM
            {
                Id = product.Id,
                ProductName = product.ProductName,
                CountInPacking = product.CountInPacking,
                CountryId = product.CountryId,
                IsRefregrator = product.IsRefregrator,
                PackingType = product.PackingType,
                ProductImage = product.ProductImage,
                ProductWeight = product.ProductWeight,
                SupplierId = product.SupplierId,
            };
        }
        public static Product Map(UpdateProductCommand command)
        {
            return new Product
            {
                Id = command.Id,
                ProductName = command.ProductName,
                CountInPacking = command.CountInPacking,
                CountryId = command.CountryId,
                IsRefregrator = command.IsRefregrator,
                PackingType = command.PackingType,
                ProductImage = command.ProductImage,
                ProductWeight = command.ProductWeight,
                SupplierId = command.SupplierId,
                // ModifierUserId
            };
        }
    }
}
