using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Suppliers.Queries
{
    public class GetSupplierDetailQuery : MediatR.IRequest<ApiResponse<GetSupplierResponseVM>>
    {
        public int Id { get; set; }
    }
}
