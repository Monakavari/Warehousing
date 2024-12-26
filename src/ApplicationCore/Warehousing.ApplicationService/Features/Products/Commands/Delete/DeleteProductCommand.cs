using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Product.Commands.Delete
{
    public class DeleteProductCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
