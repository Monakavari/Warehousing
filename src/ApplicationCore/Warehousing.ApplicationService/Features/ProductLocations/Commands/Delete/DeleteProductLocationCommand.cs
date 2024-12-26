using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.ProductLocation.Commands.Delete
{
    public class DeleteProductLocationCommand:IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
