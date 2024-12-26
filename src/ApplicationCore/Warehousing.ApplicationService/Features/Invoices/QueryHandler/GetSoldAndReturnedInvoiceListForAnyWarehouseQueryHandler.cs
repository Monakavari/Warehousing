using Warehousing.ApplicationService.Features.Invoices.Queries;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Invoices.QueryHandler
{
    public class GetSoldAndReturnedInvoiceListForAnyWarehouseQueryHandler : MediatR.IRequestHandler<GetInvoiceFullInfoListQuery, ApiResponse<List<GetInvoiceFullInfoResponseDto>>>
    {
        #region Constructor

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetSoldAndReturnedInvoiceListForAnyWarehouseQueryHandler(IInvoiceRepository invoiceRepository,
                                                                        IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion Constructor

        public async Task<ApiResponse<List<GetInvoiceFullInfoResponseDto>>> Handle(GetInvoiceFullInfoListQuery request, CancellationToken cancellationToken)
        {
            if (request.FromDate == "" || request.FromDate == null)
            {
                request.FromDate = "1300/01/01";
            }
            if (request.ToDate == "" || request.ToDate == null)
            {
                request.ToDate = "1600/01/01";
            }

            var data = await _invoiceRepository.GetSoldAndReturnedInvoiceListForAnyWarehouse(new GetInvoiceFullInfoRequestDto
            {
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                WarehouseId = request.WarehouseId,
                FiscalYearId = request.FiscalYearId
            }, cancellationToken);

            return new ApiResponse<List<GetInvoiceFullInfoResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
