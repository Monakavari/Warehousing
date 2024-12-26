using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.ProductLocation.Commands.Create
{
    public class CreateProductLocationCommand:IRequest<ApiResponse>
    {
        public int WarehouseId { get; set; }
        public string ProductLocationAddress { get; set; }
    }
}
