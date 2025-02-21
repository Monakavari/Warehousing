using Warehousing.ApplicationService.Features.ProductLocation.Commands.Create;
using Warehousing.ApplicationService.Features.ProductLocation.Commands.Update;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class ProductLocationProfile
    {
        public static ProductLocation Map(UpdateProductLocationCommand command)
        {
            return new ProductLocation
            {
                Id = command.Id,
                WarehouseId = command.WarehouseId,
                ProductLocationAddress = command.ProductLocationAddress,
            };
        }
        public static GetProductLocationResponseVM Map(ProductLocation command)
        {
            return new GetProductLocationResponseVM
            {
                Id = command.Id,
                ProductLocationAddress = command.ProductLocationAddress
            };
        }
    }
}
