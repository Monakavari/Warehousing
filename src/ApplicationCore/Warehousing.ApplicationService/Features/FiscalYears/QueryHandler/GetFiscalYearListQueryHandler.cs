using Warehousing.ApplicationService.Features.FiscalYear.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.Common.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Warehousing.ApplicationService.Features.FiscalYear.QueryHandler
{
    public class GetFiscalYearListQueryHandler : MediatR.IRequestHandler<GetFiscalYearListQuery, ApiResponse<List<GetFiscalYearResponseVM>>>
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalYearRepository;
        public GetFiscalYearListQueryHandler(IFiscalYearRepository fiscalYearRepository)
        {
            _fiscalYearRepository = fiscalYearRepository;
        }
        #endregion
        public async Task<ApiResponse<List<GetFiscalYearResponseVM>>> Handle(GetFiscalYearListQuery request, CancellationToken cancellationToken)
        {
            var data = await _fiscalYearRepository
                                  .FetchIQueryableEntity()
                                  .Select(x => new GetFiscalYearResponseVM
                                  {
                                      Id = x.Id,
                                      StartDate = PersianDate.ToShamsi(x.StartDate),
                                      EndDate = PersianDate.ToShamsi(x.EndDate),
                                      FiscalFlag = x.FiscalFlag,
                                      FiscalYearDescription = x.FiscalYearDescription
                                  })
                                  .ToListAsync(cancellationToken);

            return new ApiResponse<List<GetFiscalYearResponseVM>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
