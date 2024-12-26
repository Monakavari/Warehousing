using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.FiscalYear.Commands.Delete
{
    public class DeleteFiscalYearCommand :IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
