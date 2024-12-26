using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.FiscalYear.Queries
{
    public class GetFiscalYearListQuery : IRequest<ApiResponse<List<GetFiscalYearResponseVM>>>
    {
    }
}
