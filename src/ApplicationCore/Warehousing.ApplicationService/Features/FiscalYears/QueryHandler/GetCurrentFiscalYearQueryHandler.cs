using Warehousing.ApplicationService.Features.FiscalYears.Queries;
using Warehousing.Common;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.FiscalYears.QueryHandler
{
    public class GetCurrentFiscalYearQueryHandler : MediatR.IRequestHandler<GetCurrentFiscalYearQuery, ApiResponse<CurrentFiscalYearResponseDto>>
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalYearRepository;
        public GetCurrentFiscalYearQueryHandler(IFiscalYearRepository fiscalYearRepository)
        {
            _fiscalYearRepository = fiscalYearRepository;
        }
        #endregion
        public async Task<ApiResponse<CurrentFiscalYearResponseDto>> Handle(GetCurrentFiscalYearQuery request, CancellationToken cancellationToken)
        {
            var data = await _fiscalYearRepository.GetCurrentFiscalYearForApi(cancellationToken);
            return new ApiResponse<CurrentFiscalYearResponseDto>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
