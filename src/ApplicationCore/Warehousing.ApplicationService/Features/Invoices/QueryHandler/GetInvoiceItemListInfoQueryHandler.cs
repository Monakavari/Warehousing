using Warehousing.ApplicationService.Features.Invoices.Queries;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.Features.Invoices.QueryHandler
{
    public class GetInvoiceItemListInfoQueryHandler : MediatR.IRequestHandler<GetInvoiceItemListInfoQuery, ApiResponse<List<InvoiceItemInfoResponseDto>>>
    {
        #region Constructor
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetInvoiceItemListInfoQueryHandler(IInvoiceItemRepository invoiceItemRepository,
                                                  IUnitOfWork unitOfWork)
        {
            _invoiceItemRepository = invoiceItemRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion Constructor
        public async Task<ApiResponse<List<InvoiceItemInfoResponseDto>>> Handle(GetInvoiceItemListInfoQuery request, CancellationToken cancellationToken)
        {
            if (request.InvoiceId == 0)
                throw new AppException("اینویس مورد نظر را انتخاب کنید.");

            var data = await _invoiceItemRepository.GetInvoiceItemListInfo(request.InvoiceId, cancellationToken);

            return new ApiResponse<List<InvoiceItemInfoResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
