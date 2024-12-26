using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.ProductLocation.Commands.Update
{
    public class UpdateProductLocationCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string ProductLocationAddress { get; set; }

    }
}
