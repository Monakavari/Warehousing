using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.ProductPrice.Commands.Delete
{
    public class DeleteProductPriceCommand:IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
