using Warehousing.ApplicationService.Features.Invoices.Queries;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Invoices.QueryHandler
{
    public class GetItemReportOfAnyInvoiceListQueryHandler : MediatR.IRequestHandler<GetItemReportOfAnyInvoiceListQuery, ApiResponse<List<ItemReportOfAnyInvoiceResponseDto>>>
    {
        #region Constructor

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetItemReportOfAnyInvoiceListQueryHandler(IInvoiceRepository invoiceRepository,
                                                         IUnitOfWork unitOfWork)

        {
            _invoiceRepository = _invoiceRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion Constructor
        public async Task<ApiResponse<List<ItemReportOfAnyInvoiceResponseDto>>> Handle(GetItemReportOfAnyInvoiceListQuery request, CancellationToken cancellationToken)
        {
            if (request.FromDate == "" || request.FromDate == null)
            {
                request.FromDate = "1300/01/01";
            }
            if (request.ToDate == "" || request.ToDate == null)
            {
                request.ToDate = "1600/01/01";
            }
            var data = await _invoiceRepository.GetSeparatedInvoiceItemsReportListForPacking(new ItemReportOfAnyInvoiceRequestDto
            {
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                WarehouseId = request.WarehouseId,
                FiscalYearId = request.FiscalYearId
            }, cancellationToken);

            return new ApiResponse<List<ItemReportOfAnyInvoiceResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
