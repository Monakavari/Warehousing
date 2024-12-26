using Warehousing.ApplicationService.Features.FiscalYear.Queries;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.FiscalYear.QueryHandler
{
    public class GetFiscalYearDetailQueryHandler : MediatR.IRequestHandler<GetFiscalYearDetailQuery, ApiResponse<GetFiscalYearResponseVM>>
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalYearRepository;
        public GetFiscalYearDetailQueryHandler(IFiscalYearRepository fiscalYearRepository)
        {
            _fiscalYearRepository = fiscalYearRepository;
        }
        #endregion
        public async Task<ApiResponse<GetFiscalYearResponseVM>> Handle(GetFiscalYearDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _fiscalYearRepository.GetByIdAsync(request.Id, cancellationToken);
            var mapper = FiscalYearProfile.Map(entity);

            return new ApiResponse<GetFiscalYearResponseVM>(true, ApiResponseStatusCode.Success, mapper, "عملیات با موفقیت انجام شد");
        }
    }
}
