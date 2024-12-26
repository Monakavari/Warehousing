using Warehousing.ApplicationService.Features.Invoices.Queries;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Invoices.QueryHandler
{
    public class GetInvoiceItemsForPrintQueryHandler : MediatR.IRequestHandler<GetInvoiceItemsForPrintQuery, ApiResponse<GetDetailPrintResponseDto>>
    {
        #region Constructor
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetInvoiceItemsForPrintQueryHandler(IInvoiceRepository invoiceRepository,
                                                  IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion Constructor
        public async Task<ApiResponse<GetDetailPrintResponseDto>> Handle(GetInvoiceItemsForPrintQuery request, CancellationToken cancellationToken)
        {
            var data = await _invoiceRepository.GetInvoiceDetailListInfoForPrint(request.InvoiceId, cancellationToken);
            return new ApiResponse<GetDetailPrintResponseDto>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}

