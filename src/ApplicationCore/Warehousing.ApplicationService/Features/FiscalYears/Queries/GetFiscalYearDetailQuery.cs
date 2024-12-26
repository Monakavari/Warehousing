using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.FiscalYear.Queries
{
    public class GetFiscalYearDetailQuery : IRequest<ApiResponse<GetFiscalYearResponseVM>>
    {
        public int Id { get; set; }
    }
}
