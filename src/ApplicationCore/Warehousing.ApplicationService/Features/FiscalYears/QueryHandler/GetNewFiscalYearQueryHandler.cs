using AutoMapper;
using Warehousing.ApplicationService.Features.FiscalYears.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.FiscalYears.QueryHandler
{
    public class GetNewFiscalYearQueryHandler : MediatR.IRequestHandler<GetNewFiscalYearQuery, ApiResponse<NewFiscalYearResponseDto>>
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalYearRepository;
        public GetNewFiscalYearQueryHandler(IFiscalYearRepository fiscalYearRepository)
        {
            _fiscalYearRepository = fiscalYearRepository;
        }
        #endregion
        public async Task<ApiResponse<NewFiscalYearResponseDto>> Handle(GetNewFiscalYearQuery request, CancellationToken cancellationToken)
        {
            var data = await _fiscalYearRepository.GetNewFiscalYear(request.FiscalYearId, cancellationToken);
            var result = new NewFiscalYearResponseDto()
            {
                FiscalYearDescription = data.FiscalYearDescription,
                FiscalFlag = data.FiscalFlag,
                StartDate = PersianDate.ToShamsi(data.StartDate),
                EndDate = PersianDate.ToShamsi(data.EndDate)
            };
            return new ApiResponse<NewFiscalYearResponseDto>(true, ApiResponseStatusCode.Success, result, "عملیات با موفقیت انجام شد");
        }
    }
}
