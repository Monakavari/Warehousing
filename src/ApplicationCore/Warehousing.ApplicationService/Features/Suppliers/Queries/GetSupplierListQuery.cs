using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Suppliers.Queries
{
    public class GetsupplierListQuery :MediatR.IRequest<ApiResponse<List<GetSupplierResponseVM>>>
    {
    }
}
